using FruitHub.Service.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FruitHub.Service.Interface
{
    public interface ICategoriaService
    {
        Task<CategoriaDTO> AddCategoria(CategoriaDTO categoria);
        Task<CategoriaDTO> UpdateCategoria(long id, CategoriaDTO categoria);
        Task<CategoriaDTO> UpdateActive(long id, bool active);
        //Task<PageList<CategoriaDTO>> GetAllCategoriaAsync(PageParams pageParams);
        Task<IEnumerable<CategoriaDTO>> GetAllCategorias();
        Task<CategoriaDTO> GetIdCategoriaAsync(long id);
        Task<IEnumerable<CategoriaDTO>> GetCategoriasByNameAsync(string name);
        Task<IEnumerable<CategoriaDTO>> GetCategoriaPersonalizadaAsync(string name);
        Task<IEnumerable<CategoriaDTO>> GetCategoriasByActiveAsync();
        Task<IEnumerable<CategoriaDTO>> GetCategoriasByDeletedAsync();

    }
}
