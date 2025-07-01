using Microsoft.AspNetCore.Mvc;
using StreamFy.Api.RequestModels;
using StreamFy.Application;
using StreamFy.Core.Modelos;

namespace StreamFy.Api.Controllers;

[ApiController]
[Route("musica")]
public class MusicaController : ControllerBase
{
    private readonly PlaylistApplication _playlistApp;

    public MusicaController(PlaylistApplication playlistApp)
    {
        _playlistApp = playlistApp;
    }
    
    [HttpPost("playlist")]
    public ActionResult<Playlist> AdicionarMusicaPlaylist(MusicaActionReq actionReq)
    {
        var playlistUpdate = 
            _playlistApp.AdicionarMusica(
                actionReq.PlaylistId, 
                actionReq.musicaId);

        return playlistUpdate;
    }

    [HttpGet]
    public ActionResult<List<MusicaActionReq>> GetMusicas(int quantidade)
    {
        var musicas = _playlistApp.RecuperarMusicas(quantidade);

        if (musicas == null || !musicas.Any())
            return NotFound("Nenhuma música encontrada.");

        var musicasReq = MapMusicasToActionReq(musicas);

        return Ok(musicasReq);
    }

    private List<MusicaActionReq> MapMusicasToActionReq(List<Musica> musicas)
    {
        return musicas.Select(m => new MusicaActionReq
        {
            musicaId = m.Id,
            BandaNome = m.Autor?.Nome ?? string.Empty,
            // Defina os outros campos conforme necessário
            UsuarioId = 0,
            PlaylistId = 0,
            Favorito = false
        }).ToList();
    }
}