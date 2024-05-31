using FruitHub.Domain;
using FruitHub.Infra.Data.Context;
using FruitHub.Infra.Data.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FruitHub.Infra.Data
{
    public class CidadeRepository : BaseRepository, ICidadeRepository
    {
        private readonly MySqlContext _context;
        public CidadeRepository(MySqlContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Cidade>> GetAllCidade()
        {
           List<Cidade> cidades = await _context.Cidade.Include(e => e.Estado).ToListAsync();
            return cidades;
        }

        public async Task<IEnumerable<Cidade>> GetAllCidadeEstado(long id)
        {
          return await _context.Cidade.Where(c => c.EstadoId == id).Include(e => e.Estado).ToListAsync();
        }

        public async Task<IEnumerable<Cidade>> JoinGetAllCidadeEstado(long id)
        {
            var cidades = await _context.Cidade.Where(c => c.EstadoId == id).Include(e => e.Estado).ToListAsync();
            return cidades;
        }

        public async Task<Cidade> GetCidadeId(long id)
        {
            return await _context.Cidade.Where( c => c.Id == id).Include(e => e.Estado).FirstOrDefaultAsync();
        }

       
    }
}
