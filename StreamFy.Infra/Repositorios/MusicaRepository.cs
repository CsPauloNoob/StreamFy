using Microsoft.EntityFrameworkCore;
using StreamFy.Core.Interfaces;
using StreamFy.Core.Modelos;
using StreamFy.Infra.Dados;

namespace StreamFy.Infra.Repositorios
{
    public class MusicaRepository : IMusicaRepository
    {
        private readonly StramFyContext _context;

        public MusicaRepository(StramFyContext context)
        {
            _context = context;
        }

        public async Task<Musica> RecuperarMusicaPorId(int id)
        {
            var musica = await _context.Musicas
                .Include(m => m.Autor)
                .FirstOrDefaultAsync(m => m.Id == id);
            return musica;
        }


        public async Task<List<Musica>> RecuperarMusicas(int limite)
        {
            var musicas = await _context.Musicas
                .Take(limite)
                .Include(m => m.Autor)
                .ToListAsync();

            return musicas;
        }

        public async Task<List<Musica>> RecuperarMusicasPorNome(string nome)
        {
            var nomeLower = nome.ToLower();
            return await _context.Musicas
                .Include(m => m.Autor)
                .Where(m => m.Nome.ToLower().Contains(nomeLower))
                .ToListAsync();
        }

        public async Task<List<Musica>> RecuperarMusicasPorAutor(string nomeAutor)
        {
            var nomeAutorLower = nomeAutor.ToLower();
            return await _context.Musicas
                .Include(m => m.Autor)
                .Where(m => m.Autor != null && m.Autor.Nome.ToLower().Contains(nomeAutorLower))
                .ToListAsync();
        }
    }
}
