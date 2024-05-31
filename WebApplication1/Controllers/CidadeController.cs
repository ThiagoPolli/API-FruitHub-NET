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
            var cidade = await _service.GetCidadeId(id);
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

        [HttpGet("estado-join/{id}")]
        public async Task<ActionResult<IEnumerable<CidadeDTO>>> JoinFindByCidadeEstado(long id)
        {
            var cidades = await _service.JoinGetAllCidadeEstado(id);
            if (cidades == null || cidades.Count() <= 0) { return NotFound($" Cidade Não encontrado com ID: {id}"); }
            return Ok(cidades);
        }

        [HttpPost]
        public async Task<ActionResult<CidadeInsertDTO>> CreateCidade([FromBody]CidadeInsertDTO cidadeDto)
        {
            if(cidadeDto == null) { return BadRequest("Erro ao criar Categoria"); }

            var cidade = await _service.AddCIdade(cidadeDto);
            return Ok(cidade);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<CidadeInsertDTO>> Update([FromBody]CidadeInsertDTO cidadeInsertDto, long id)
        {
            var cidadeId = await _service.GetCidadeId(id); 
            if (cidadeId == null) { NotFound($" Cidade Não encontrado com id: {id}"); }

            cidadeInsertDto.Id = cidadeId.Id;
            var result = await _service.UpdateCIdade(cidadeInsertDto.Id, cidadeInsertDto);
            return Ok(result);
        }

    }
}
