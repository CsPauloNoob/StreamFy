using StreamFy.Core.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StreamFy.Core.Interfaces
{
    public interface IUsuarioRepository
    {
        /// <summary>
        /// Busca um usuário pelo email.
        /// </summary>
        /// <param name="email">Email do usuário.</param>
        /// <returns>Usuário encontrado ou null se não existir.</returns>
        Task<Usuario> BuscarPorEmailAsync(string email);
        /// <summary>
        /// Adiciona um novo usuário ao repositório.
        /// </summary>
        /// <param name="usuario">Usuário a ser adicionado.</param>
        Task AdicionarAsync(Usuario usuario);
        /// <summary>
        /// Atualiza as informações de um usuário existente.
        /// </summary>
        /// <param name="usuario">Usuário com as informações atualizadas.</param>
        Task AtualizarAsync(Usuario usuario);
    }
}
