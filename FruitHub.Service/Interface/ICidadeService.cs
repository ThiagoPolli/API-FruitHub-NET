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
        Task<CidadeDTO> GetAllCidadeIdo(long id);
    }
}
