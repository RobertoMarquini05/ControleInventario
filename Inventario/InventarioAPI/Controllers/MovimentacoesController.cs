using InventarioAPI.Models;
using InventarioAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace InventarioAPI.Controllers
{
    [ApiController]
    [Route("api/movimentacoes")]
    public class MovimentacoesController : ControllerBase
    {
        private readonly MovimentacaoService _service = new();

        [HttpGet]
        public IActionResult GetTodas()
        {
            return Ok(_service.ListarTodas());
        }

        [HttpGet("item/{itemId}")]
        public IActionResult GetPorItem(Guid itemId)
        {
            var movs = _service.PorItem(itemId);
            return Ok(movs);
        }

        [HttpGet("tipo/{tipo}")]
        public IActionResult GetPorTipo(string tipo)
        {
            var movs = _service.PorTipo(tipo);
            return Ok(movs);
        }

        [HttpPost]
        public IActionResult Registrar([FromBody] Movimentacao mov)
        {
            _service.Registrar(mov);
            return CreatedAtAction(nameof(GetPorItem), new { itemId = mov.ItemId }, mov);
        }
    }
}
