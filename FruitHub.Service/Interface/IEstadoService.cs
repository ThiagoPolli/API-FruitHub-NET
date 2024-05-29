using FruitHub.Service.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FruitHub.Service.Interface
{
    public interface IEstadoService
    {
        Task<IEnumerable<EstadoDTO>> GetAllEstadoAsyc();
        Task<EstadoDTO> GetEstadoIdAsync(long id);
    }
}
