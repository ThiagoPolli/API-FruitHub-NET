using AutoMapper;
using FruitHub.Domain;
using FruitHub.Infra.Data.Models;
using FruitHub.Infra.Data.Repository;
using FruitHub.Service.DTOs;
using FruitHub.Service.Interface;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FruitHub.Service
{
    public class ProdutoService : IProdutoService
    {

        private readonly IBaseRepository _baseRepository;
        private readonly IProdutoRepository _produtoRepository;
        private readonly IMapper _mapper;

        public ProdutoService(IBaseRepository baseRepository, IProdutoRepository produtoRepository, IMapper mapper) 
        {
            _baseRepository = baseRepository;
            _produtoRepository = produtoRepository;
            _mapper = mapper;
        }
        public async Task<IEnumerable<ProdutoDTO>> GetAllProdutos()
        {
            List<Produto> produtos = (List<Produto>)await _produtoRepository.GetProdutosAll();
            return _mapper.Map<List<ProdutoDTO>>(produtos);
        }

        //Buscar Por Personalizada
        public async Task<IEnumerable<ProdutoDTO>> GetProdutoPersonalizado(string name)
        {
            try
            {
               List<Produto> produtosName = (List<Produto>)await _produtoRepository.GetProdutoPersonalizado(name);
                if (produtosName == null) { return null; }
            
                return _mapper.Map<List<ProdutoDTO>>(produtosName);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        //BUSCAR POR ID
        public async Task<ProdutoDTO> GetIdProdutosaAsync(long id)
        {
            try
            {
                var produto = await _produtoRepository.GetProdutosByIdAsync(id);
                if (produto == null) return null;

                return _mapper.Map<ProdutoDTO>(produto);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        //BUSCAR POR CATEGORIA ID
        public async Task<IEnumerable<ProdutoDTO>> GetIdProdutoCategoriasaAsync(long id)
        {

            try
            {
                List<Produto> produtos = (List<Produto>)await _produtoRepository.GetProdutoCategoria(id);
                if (produtos == null) return null;

                return _mapper.Map<List<ProdutoDTO>>(produtos);
            }
            catch(Exception ex) 
            {
                throw new Exception(ex.Message);
            }


        }

        //BUSCAR POR PAGINAS
        public async Task<PageList<ProdutoDTO>> GetByPageProdutos(PageParams pageParams, bool ativo)
        {
            try
            {
                var produtos = await _produtoRepository.GetProdutoPage(pageParams, ativo);
                if (produtos == null) return null;

                var result = _mapper.Map<PageList<ProdutoDTO>>(produtos);

                result.CurrentPage = produtos.CurrentPage;
                result.TotalPages = produtos.TotalPages;
                result.PageSize = produtos.PageSize;
                result.TotalCount = produtos.TotalCount;

                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }



        //ADICIONAR NOVO PRODUTO
        public async Task<ProdutoDTO> AddProduto(ProdutoDTO dto)
        {
            try
            {
                Produto produto = _mapper.Map<Produto>(dto);
                _baseRepository.Add(produto);
                if( await _baseRepository.SaveChangesAsync() )
                {
                    var produtoReturn = await _produtoRepository.GetProdutosByIdAsync(produto.Id);
                    return _mapper.Map<ProdutoDTO>(produtoReturn);
                }
                else { return null; }
            }
            catch (Exception ex)
            {
                throw new Exception("ERRO ProdutoService " + ex.Message);
            }
        }

        //ATUALIZAR PRODUTO
        public async Task<ProdutoDTO> UpdateProduto(long id, ProdutoDTO dto)
        {
            try
            {
                var produto = await _produtoRepository.GetProdutosByIdAsync(id);

                if (produto == null) return null;

                dto.Id = produto.Id;
                _mapper.Map(dto, produto);

                _baseRepository.Update<Produto>(produto);

                if (await _baseRepository.SaveChangesAsync())
                {
                    var produtoResult = await _produtoRepository.GetProdutosByIdAsync(produto.Id);
                    return _mapper.Map<ProdutoDTO>(produtoResult);
                }
                else { return null; }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    
    }
}
