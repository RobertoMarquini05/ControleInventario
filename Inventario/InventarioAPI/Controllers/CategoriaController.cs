using InventarioAPI.Models;
using InventarioAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace InventarioAPI.Controllers
{
    [ApiController]
    [Route("api/categorias")]
    public class CategoriasController : ControllerBase
    {
        private readonly CategoriaService _service = new();

        [HttpGet]
        public IActionResult GetTodos()
        {
            return Ok(_service.Listar());
        }

        [HttpGet("{id}")]
        public IActionResult GetPorId(Guid id)
        {
            var categoria = _service.ObterPorId(id);
            if (categoria == null) return NotFound();
            return Ok(categoria);
        }

        [HttpPost]
        public IActionResult Criar([FromBody] Categoria categoria)
        {
            _service.Criar(categoria);
            return CreatedAtAction(nameof(GetPorId), new { id = categoria.Id }, categoria);
        }

        [HttpPut("{id}")]
        public IActionResult Atualizar(Guid id, [FromBody] Categoria categoria)
        {
            if (!_service.Atualizar(id, categoria)) return NotFound();
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
