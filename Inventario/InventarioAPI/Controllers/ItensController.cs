using InventarioAPI.Models;
using InventarioAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace InventarioAPI.Controllers
{
    [ApiController]
    [Route("api/itens")]
    public class ItensController : ControllerBase
    {
        private readonly ItemService _service = new();

        [HttpGet]
        public IActionResult GetTodos() 
        {
            return Ok(_service.Listar());
        }

        [HttpGet("{id}")]
        public IActionResult GetPorId(Guid id)
        {
            var item = _service.ObterPorId(id);
            if (item == null) return NotFound();
            return Ok(item);
        }

        [HttpPost]
        public IActionResult Criar([FromBody] Item item)
        {
            _service.Criar(item);
            return CreatedAtAction(nameof(GetPorId), new { id = item.Id }, item);
        }

        [HttpPut("{id}")]
        public IActionResult Atualizar(Guid id, [FromBody] Item item)
        {
            if (!_service.Atualizar(id, item)) return NotFound();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Deletar(Guid id)
        {
            if (!_service.Deletar(id)) return NotFound();
            return NoContent();
        }
    }
}
