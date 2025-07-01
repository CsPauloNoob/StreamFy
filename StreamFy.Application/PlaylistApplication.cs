using StreamFy.Core.Interfaces;
using StreamFy.Core.Modelos;

namespace StreamFy.Application;

public class PlaylistApplication
{
    private readonly IMusicaRepository _musicaRepo;

    public PlaylistApplication(IMusicaRepository musicaRepository)
    {
        _musicaRepo = musicaRepository;
    }

    public Playlist AdicionarMusica(int playlistId, int musicaId)
    {
        return new Playlist();
    }

    public List<Musica> RecuperarMusicas(int quantidade)
    {
        var musicas = _musicaRepo.RecuperarMusicas(quantidade).GetAwaiter().GetResult();

        return musicas ?? new List<Musica>();
    }

    public async Task<List<Musica>> RecuperarMusicasPorNome(string nome)
    {
        
        var musicas =  await _musicaRepo.RecuperarMusicasPorNome(nome);

        return musicas ?? new List<Musica>();
    }


    public async Task<List<Musica>> RecuperarMusicasPorAutor(string nomeAutor)
    {
        return await _musicaRepo.RecuperarMusicasPorAutor(nomeAutor);
    }
}