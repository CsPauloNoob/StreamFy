using StreamFy.Core.Interfaces;
using StreamFy.Core.Modelos;

namespace StreamFy.Application;

public class PlaylistApplication
{
    private readonly IMusicaRepository _musicaRepo;
    private readonly IAutorRepository _autorRepo;
    private readonly IUsuarioRepository _usuarioRepo;

    public PlaylistApplication(IMusicaRepository musicaRepository, IAutorRepository autorRepository, IUsuarioRepository usuarioRepository)
    {
        _musicaRepo = musicaRepository;
        _autorRepo = autorRepository;
        _usuarioRepo = usuarioRepository;
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


    public async Task<List<Autor>> RecuperarAutores(int quantidade = 5)
    {
        return await _autorRepo.RecuperarAutores(quantidade);
    }

    public async Task<bool> FavoritarMusica(Musica musica, string idUsuario)
    {
        var musicaBanco = await _musicaRepo.RecuperarMusicaPorId(musica.Id);
        var usuario = await _usuarioRepo.BuscarPorEmailAsync(idUsuario);

        usuario.Playlists[0].AdicionarMusica(musicaBanco);

        await _usuarioRepo.Salvar();

        return true;
    }

}