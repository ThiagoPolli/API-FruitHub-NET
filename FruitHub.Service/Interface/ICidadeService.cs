using FruitHub.Domain;
using FruitHub.Service.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FruitHub.Service.Interface
{
    public interface ICidadeService
    {
        Task<IEnumerable<CidadeDTO>> GetAllCidade();
        Task<IEnumerable<CidadeDTO>> GetAllCidadeEstado(long id); 
        Task<IEnumerable<CidadeDTO>> JoinGetAllCidadeEstado(long id);
        Task<CidadeDTO> GetCidadeId(long id);
        Task<CidadeInsertDTO> AddCIdade(CidadeInsertDTO cidade);
        Task<CidadeInsertDTO> UpdateCIdade(long id, CidadeInsertDTO cidade);
    }
}
