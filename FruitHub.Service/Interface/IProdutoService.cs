using FruitHub.Infra.Data.Models;
using FruitHub.Service.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FruitHub.Service.Interface
{
    public interface IProdutoService
    {
        Task<PageList<ProdutoDTO>> GetByPageProdutos(PageParams pageParams, bool ativo);
        Task<ProdutoDTO> AddProduto(ProdutoDTO produto);
        Task<ProdutoDTO> UpdateProduto(long id, ProdutoDTO produto);
        Task<IEnumerable<ProdutoDTO>> GetAllProdutos();
        Task<ProdutoDTO> GetIdProdutosaAsync(long id);
        Task<IEnumerable<ProdutoDTO>> GetIdProdutoCategoriasaAsync(long id);
        Task<IEnumerable<ProdutoDTO>> GetProdutoPersonalizado(string name);
    }
}
