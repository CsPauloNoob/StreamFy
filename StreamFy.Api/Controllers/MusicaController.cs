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
    public ActionResult<List<Musica>> GetMusicas(int quantidade)
    {
        var musicas = _playlistApp.RecuperarMusicas(quantidade);

        if (musicas == null || !musicas.Any())
            return NotFound("Nenhuma música encontrada.");

        return Ok(musicas);
    }
}