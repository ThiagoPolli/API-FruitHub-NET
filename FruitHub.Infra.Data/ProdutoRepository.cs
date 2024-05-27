using FruitHub.Domain;
using FruitHub.Infra.Data.Context;
using FruitHub.Infra.Data.Models;
using FruitHub.Infra.Data.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FruitHub.Infra.Data
{
    public class ProdutoRepository : BaseRepository, IProdutoRepository
    {
        private readonly MySqlContext _context;
        public ProdutoRepository(MySqlContext context) : base(context)
        {
            _context = context;
        }


        public async Task<IEnumerable<Produto>> GetProdutosAll()
        {
            List<Produto> produtos = await _context.Produto.ToListAsync();
            return produtos;
        }

        public async Task<Produto> GetProdutosByIdAsync(long id)
        {
          return await _context.Produto.FindAsync(id);
        }

        public async Task<IEnumerable<Produto>> GetProdutoPersonalizado(string name)
        {
            var sql = $"SELECT * FROM Produto WHERE LOWER(Nome) LIKE '{name.ToLower()}%';";

            return await _context.Produto.FromSqlRaw(sql).ToListAsync();
        }

        public async Task<IEnumerable<Produto>> GetProdutoCategoria(long id)
        {
           return await _context.Produto.Where(p => p.CategoriaId == id).ToListAsync();
        }

        public async Task<PageList<Produto>> GetProdutoPage(PageParams pageParams)
        {
            IQueryable<Produto> query = _context.Produto;
            
            query = query.AsNoTracking();

            return await PageList<Produto>.CreateAsync(query, pageParams.Pagenumber, pageParams.PageSize);
        }
    }
}
