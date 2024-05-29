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
    public class EstadoRepository : BaseRepository, IEstadoRepository
    {
        private readonly MySqlContext _context;
        public EstadoRepository(MySqlContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Estado>> GetAllEstado()
        {
            List<Estado> estados = await _context.Estado.ToListAsync();
            return estados;
        }

        public async Task<Estado> GetEstadoId(long id)
        {
            return await _context.Estado.FindAsync(id);
        }
    }
}
