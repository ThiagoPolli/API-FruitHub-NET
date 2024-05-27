using FruitHub.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FruitHub.Infra.Data.Repository
{
    public interface ICategoriaRepository : IBaseRepository
    {
        //Task<PageList<Categoria>> GetCategoriasByAllAsync(PageParams pageParams);
        Task<IEnumerable<Categoria>> GetGetAllCategoriasAll();
        Task<Categoria> GetCategoriaByIdAsync(long id);
        Task<IEnumerable<Categoria>> GetCategoriasByNameAsync(string name);
        Task<IEnumerable<Categoria>> GetcategoriaPersonalizada(string name);
        Task<IEnumerable<Categoria>> GetCategoriasActive();
        Task<IEnumerable<Categoria>> GetCategoriasDeleted();

    }
}
