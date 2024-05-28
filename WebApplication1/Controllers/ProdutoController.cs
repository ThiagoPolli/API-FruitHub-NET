using FruitHub.Api.Extension;
using FruitHub.Infra.Data.Models;
using FruitHub.Service.DTOs;
using FruitHub.Service.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;

namespace FruitHub.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        private readonly IProdutoService _service;

        public ProdutoController(IProdutoService service)
        {
            _service = service;
        }

        //BUSCAR TODOS
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProdutoDTO>>> FindAll()
        {
            var produtos = await _service.GetAllProdutos();
            return Ok(produtos);
        }

        //BUSCAR POR ID
        [HttpGet("{id}")]
        public async Task<ActionResult<ProdutoDTO>> FindById(long id)
        {
            var produto = await _service.GetIdProdutosaAsync(id);
            if (produto == null) { return NotFound($" Produto Não encontrado com id: {id}"); }
            return Ok(produto);
        }

        //BUSCA PERSONALIZADO
        [HttpGet("nome")]
        public async Task<ActionResult<IEnumerable<ProdutoDTO>>> FindByNamePersonalizado([FromQuery] string name)
        {
            var produto = await _service.GetProdutoPersonalizado(name);
            if (produto == null) { return NotFound($" Produto Não encontrado com Nome: {name}"); }
            return Ok(produto);
        }

        //BUSCA POR ID CATEGORIA
        [HttpGet("categoria")]
        public async Task<ActionResult<IEnumerable<ProdutoDTO>>> FindByProdutoCategoria([FromQuery] long idCategoria)
        {
            var produtos = await _service.GetIdProdutoCategoriasaAsync(idCategoria);
            if (produtos == null)
            {
                return NotFound($" Produto Não encontrado com essa Categoria: {idCategoria}");
            }
            else
            {
                return Ok(produtos);
            }

        }

        //BUSCAR POR PAGINA
        [HttpGet("page")]
        public async Task<IActionResult> GetProdutoPage([FromQuery]PageParams pageParams, bool ativo)
        {
            try
            {
                var produtos = await _service.GetByPageProdutos(pageParams, ativo);
                if (produtos == null) { return NotFound(); }

               // Response.AddPagination(produtos.CurrentPage, produtos.PageSize, produtos.TotalCount, produtos.TotalPages);
               Response.AddPagination(produtos.CurrentPage, produtos.PageSize, produtos.TotalCount, produtos.TotalPages);
                return Ok(produtos);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar recuperar Produto. Erro: {ex.Message}");
            }
        }


        //ADICIONAR
        [HttpPost]
        public async Task<ActionResult<ProdutoDTO>> Create([FromBody] ProdutoDTO produtoDTO)
        {
            if (produtoDTO == null) { return BadRequest("Erro ao Adicionar Produto"); }

            var produto = await _service.AddProduto(produtoDTO);
            return Ok(produto);
        }

        //ATUALIZAR
        [HttpPut("{id}")]
        public async Task<ActionResult<ProdutoDTO>> Update([FromBody] ProdutoDTO produtoDTO, long id)
        {
            var produtoId = await _service.GetIdProdutosaAsync(id);
            if (produtoId == null)
            {
                return NotFound($" Produto Não encontrado com id: {id}");
            }
            else
            {
                produtoDTO.Id = produtoId.Id;
                var produtoResult = await _service.UpdateProduto(produtoDTO.Id, produtoDTO);
                return Ok(produtoResult);
            }
        }
    }
}
