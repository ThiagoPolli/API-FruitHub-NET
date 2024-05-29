using FruitHub.Service.DTOs;
using FruitHub.Service.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FruitHub.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstadoController : ControllerBase
    {
        private readonly IEstadoService _estadoService;

        public EstadoController(IEstadoService estadoService)
        {
            _estadoService = estadoService;
            
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<EstadoDTO>>> FindAll()
        {
            var estados = await _estadoService.GetAllEstadoAsyc();
            return Ok(estados);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<EstadoDTO>> FindById(long id)
        {
            var estado = await _estadoService.GetEstadoIdAsync(id);
            if(estado == null) { return NotFound($" Estado Não encontrado com id: {id}"); }
            return Ok(estado);
        }
    }
}
