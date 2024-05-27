using FruitHub.Service.DTOs;
using FruitHub.Service.Interface;
using Microsoft.AspNetCore.Mvc;

namespace FruitHub.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {
       
        private readonly ICategoriaService _service;

        public CategoriaController( ICategoriaService service)
        {
            _service = service;
        }

        //BUSCAR TODAS
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategoriaDTO>>> findAll()
        {
            var categorias = await _service.GetAllCategorias();
            return Ok(categorias);
        }

        //BUSCAR POR ATIVOS
        [HttpGet("ativo")]
        public async Task<ActionResult<IEnumerable<CategoriaDTO>>> findByActive()
        {
            var categorias = await _service.GetCategoriasByActiveAsync();
            return Ok(categorias);
        }

        //BUSCAR POR DESATIVADOS
        [HttpGet("deletado")]
        public async Task<ActionResult<IEnumerable<CategoriaDTO>>> findByDeleted()
        {
            var categorias = await _service.GetCategoriasByDeletedAsync();
            return Ok(categorias);
        }

        //BUSCAR POR NOME
        [HttpGet("nomeCategoria")]
        public async Task<ActionResult<IEnumerable<CategoriaDTO>>> findByName([FromQuery] string name)
        {
            var categoria = await _service.GetCategoriasByNameAsync(name);
            if (categoria == null) { return NotFound($" Categoria Não encontrado com Nome: {name}"); }
            return Ok(categoria);
        }

        //BUSCAR POR NOME PERSONALIZADO
        [HttpGet("nome")]
        public async Task<ActionResult<IEnumerable<CategoriaDTO>>> findByNamePErsonalizado([FromQuery] string name)
        {
            var categoria = await _service.GetCategoriaPersonalizadaAsync(name);
            if (categoria == null) { return NotFound($" Categoria Não encontrado com Nome: {name}"); }
            return Ok(categoria);
        }

        //BUSCAR POR ID
        [HttpGet("{id}")]
        public async Task<ActionResult<CategoriaDTO>> findById(long id)
        {
            var categoria = await _service.GetIdCategoriaAsync(id);
            if (categoria == null) { return NotFound($" Categoria Não encontrado com id: {id}"); }
            return Ok(categoria);
        }

        //ADICIONAR 
        [HttpPost]
        public async Task<ActionResult<CategoriaDTO>> create([FromBody] CategoriaDTO categoriaDTO)
        {
            if (categoriaDTO == null) { return BadRequest("Erro ao criar Categoria"); }

            var categoria = await _service.AddCategoria(categoriaDTO);
            return Ok(categoria);

        }

        //ATUALIZAR
        [HttpPut("{id}")]
        public async Task<ActionResult<CategoriaDTO>> update([FromBody] CategoriaDTO categoriaDTO, long id)
        {
            var categoriaId = await _service.GetIdCategoriaAsync(id);

            if (categoriaId == null) {
                return NotFound($" Categoria Não encontrado com id: {id}");
            }
            else
            {
                categoriaDTO.Id = categoriaId.Id;
               var categoriaResult = await _service.UpdateCategoria(categoriaDTO.Id, categoriaDTO);
                return Ok(categoriaResult);
            }


        }
        //ATIVAR OU DESATIVAR 
        [HttpPatch("ativo/{id}")]
        public async Task<ActionResult<CategoriaDTO>> updateActive([FromBody] bool active, long id)
        {
            var categoriaId = await _service.GetIdCategoriaAsync(id);
            if (categoriaId == null)
            {
                return NotFound($" Categoria Não encontrado com id: {id}");
            }
            else
            {
               var categoriaResult = await _service.UpdateActive(categoriaId.Id, active);
                return Ok(categoriaResult);
            }
        }
    }
}
