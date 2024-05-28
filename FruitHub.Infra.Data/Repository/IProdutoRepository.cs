using FruitHub.Domain;
using FruitHub.Infra.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FruitHub.Infra.Data.Repository
{
    public interface IProdutoRepository : IBaseRepository
    {
        Task<PageList<Produto>> GetProdutoPage(PageParams pageParams, bool ativo);
        Task<IEnumerable<Produto>> GetProdutosAll();
        Task<Produto> GetProdutosByIdAsync(long id);
        Task<IEnumerable<Produto>> GetProdutoPersonalizado(string name);
        Task<IEnumerable<Produto>> GetProdutoCategoria(long id);
    }
}
