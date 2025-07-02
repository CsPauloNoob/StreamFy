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

    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly StramFyContext _context;

        public UsuarioRepository(StramFyContext context)
        {
            _context = context;
        }


        async Task IUsuarioRepository.AdicionarAsync(Usuario usuario)
        {
            _context.Usuarios.Add(usuario);
            await _context.SaveChangesAsync();
            return;
        }

        Task IUsuarioRepository.AtualizarAsync(Usuario usuario)
        {
            throw new NotImplementedException();
        }

        async Task<Usuario> IUsuarioRepository.BuscarPorEmailAsync(string email)
        {
            var usuario = await _context.Usuarios
                .Where(u => u.Email == email)
                .Include(u => u.Playlists)
                .FirstOrDefaultAsync();

            return usuario;
        }

        async Task IUsuarioRepository.Salvar()
        {
            await _context.SaveChangesAsync();
        }
    }
}
