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
    
    [HttpPost]
    public ActionResult<Playlist> AdicionarMusicaPlaylist(MusicaActionReq actionReq)
    {
        var playlistUpdate = 
            _playlistApp.AdicionarMusica(
                actionReq.PlaylistId, 
                actionReq.musicaId);

        return playlistUpdate;
    }
}