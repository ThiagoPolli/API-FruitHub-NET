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
           List<Cidade> cidades = await _context.Cidade.ToListAsync();
            return cidades;
        }

        public async Task<IEnumerable<Cidade>> GetAllCidadeEstado(long id)
        {
          return await _context.Cidade.Where(c => c.EstadoId == id).ToListAsync();
        }

        public async Task<Cidade> GetAllCidadeId(long id)
        {
            return await _context.Cidade.FindAsync(id);
        }
    }
}
