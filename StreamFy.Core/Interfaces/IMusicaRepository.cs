using StreamFy.Core.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StreamFy.Core.Interfaces
{
    public interface IMusicaRepository
    {
        Task<Musica> RecuperarMusicaPorId(int id);
        Task<List<Musica>> RecuperarMusicas(int limite);
        Task<List<Musica>> RecuperarMusicasPorNome(string nome);
        Task<List<Musica>> RecuperarMusicasPorAutor(string nomeAutor);
    }
}
