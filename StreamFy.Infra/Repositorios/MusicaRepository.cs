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


        public async Task<List<Musica>> RecuperarMusicas(int limite)
        {
            var musicas = await _context.Musicas
                .Take(limite)
                .ToListAsync();

            return musicas;
        }
    }
}
