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


        Task IUsuarioRepository.AdicionarAsync(Usuario usuario)
        {
            _context.Usuarios.Add(usuario);
            return _context.SaveChangesAsync();
        }

        Task IUsuarioRepository.AtualizarAsync(Usuario usuario)
        {
            throw new NotImplementedException();
        }

        Task<Usuario> IUsuarioRepository.BuscarPorEmailAsync(string email)
        {
            throw new NotImplementedException();
        }
    }
}
