using FruitHub.Infra.Data.Context;
using FruitHub.Infra.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FruitHub.Infra.Data
{
    public class BaseRepository : IBaseRepository
    {
        private readonly MySqlContext _context;
        public BaseRepository(MySqlContext context)
        {
            _context = context;
        }

        public void Add<T>(T entity) where T : class
        {
           _context.AddAsync(entity);
        }
        public void Update<T>(T entity) where T : class
        {
            _context.Update(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync()) > 0;
        }

       
    }
}
