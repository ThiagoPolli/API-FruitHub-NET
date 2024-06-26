﻿using FruitHub.Domain;
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
    public class CategoriaRepository : BaseRepository, ICategoriaRepository
    {
        private readonly MySqlContext _context;
        public CategoriaRepository(MySqlContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Categoria>> GetGetAllCategoriasAll()
        {
           List<Categoria> categorias = await _context.Categoria.ToListAsync();
            return categorias;
        }
        public async Task<Categoria> GetCategoriaByIdAsync(long id)
        {
           return await _context.Categoria.FindAsync(id);
        }

        public async Task<IEnumerable<Categoria>> GetCategoriasByNameAsync(string name)
        {
            // return await _context.Categoria.SingleOrDefaultAsync(c => c.Name == name.ToLower());
            return await _context.Categoria
                .Where(c => c.Name.ToLower().Contains(name.ToLower()))
                .ToListAsync();
        }

        public async Task<IEnumerable<Categoria>> GetCategoriasActive()
        {
            return await _context.Categoria.Where(c => c.Active == true).ToListAsync();
        }

        public async Task<IEnumerable<Categoria>> GetCategoriasDeleted()
        {
            return await _context.Categoria.Where(c => c.Active == false).ToListAsync();
        }

        public async Task<IEnumerable<Categoria>> GetcategoriaPersonalizada(string name)
        {
            // Consulta SQL personalizada
            var sql = $"SELECT * FROM Categoria WHERE LOWER(Name) LIKE '{name.ToLower()}%';";

            // Execute a consulta SQL e obtenha as categorias correspondentes
            return await _context.Categoria.FromSqlRaw(sql).ToListAsync();
        }
    }
}
