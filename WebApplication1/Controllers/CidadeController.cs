using FruitHub.Domain;
using FruitHub.Service.DTOs;
using FruitHub.Service.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;

namespace FruitHub.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CidadeController : ControllerBase
    {
        private readonly ICidadeService _service;

        public CidadeController(ICidadeService service)
        {
            _service = service;
        }

        [HttpGet]
       public async Task<ActionResult<IEnumerable<CidadeDTO>>> FindAllCidade()
        {
            var cidades = await _service.GetAllCidade();
            return Ok(cidades);
        }

        [HttpGet("{id}")]   
        public async Task<ActionResult<CidadeDTO>> FindById(long id)
        {
            var cidade = await _service.GetAllCidadeIdo(id);
            if(cidade == null || cidade.Id <  0) { return NotFound($" Cidade Não encontrado com ID: {id}"); }

            return Ok(cidade);
        }

        [HttpGet("estado/{id}")]
        public async Task<ActionResult<IEnumerable<CidadeDTO>>> FindByCidadeEstado(long id)
        {
            var cidades  = await _service.GetAllCidadeEstado(id);
            if (cidades == null || cidades.Count() <= 0) { return NotFound($" Cidade Não encontrado com ID: {id}"); }
            return Ok(cidades);
        }

    }
}
