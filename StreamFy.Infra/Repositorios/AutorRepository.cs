using Microsoft.EntityFrameworkCore;
using StreamFy.Core.Interfaces;
using StreamFy.Core.Modelos;
using StreamFy.Infra.Dados;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StreamFy.Infra.Repositorios
{
    public class AutorRepository : IAutorRepository
    {
        private readonly StramFyContext _context;

        public AutorRepository(StramFyContext context)
        {
            _context = context;
        }

        public async Task<List<Autor>> RecuperarAutores(int quantidade)
        {
            return await _context.Autores
                .OrderBy(a => a.Nome)
                .Take(quantidade)
                .ToListAsync();
        }
    }
}
