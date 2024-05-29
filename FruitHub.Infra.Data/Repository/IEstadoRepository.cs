using FruitHub.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FruitHub.Infra.Data.Repository
{
    public interface IEstadoRepository
    {
        Task<IEnumerable<Estado>> GetAllEstado();
        Task<Estado> GetEstadoId(long id);
    }
}
