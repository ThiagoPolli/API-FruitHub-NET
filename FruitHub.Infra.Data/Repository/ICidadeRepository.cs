using FruitHub.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FruitHub.Infra.Data.Repository
{
    public interface ICidadeRepository : IBaseRepository
    {
        Task<IEnumerable<Cidade>> GetAllCidade();
        Task<IEnumerable<Cidade>> GetAllCidadeEstado(long id);
        Task<Cidade> GetAllCidadeId(long id);

    }
}
