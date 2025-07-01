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
        try
        {
            var playlistUpdate =
                _playlistApp.AdicionarMusica(
                    actionReq.PlaylistId,
                    actionReq.musicaId);

            return playlistUpdate;
        }
        catch (Exception ex)
        {
            return BadRequest($"Erro ao adicionar música à playlist: {ex.Message}");
        }
    }

    [HttpGet]
    public ActionResult<List<MusicaActionReq>> GetMusicas(int quantidade)
    {
        try
        {
            var musicas = _playlistApp.RecuperarMusicas(quantidade);

            if (musicas == null || !musicas.Any())
                return NotFound("Nenhuma música encontrada.");

            var musicasReq = MapMusicasToActionReq(musicas);

            return Ok(musicasReq);
        }
        catch (Exception ex)
        {
            return BadRequest($"Erro ao recuperar músicas: {ex.Message}");
        }
    }

    private List<MusicaActionReq> MapMusicasToActionReq(List<Musica> musicas)
    {
        return musicas.Select(m => new MusicaActionReq
        {
            Nome = m.Nome,
            musicaId = m.Id,
            BandaNome = m.Autor?.Nome ?? string.Empty,
            PlaylistId = 0,
            Favorito = false
        }).ToList();
    }

    [HttpGet("buscar")]
    public async Task<ActionResult<List<MusicaActionReq>>> BuscarMusicaPorNome(string nome)
    {
        try
        {
            var musicas = await _playlistApp.RecuperarMusicasPorNome(nome);

            if (musicas == null || !musicas.Any())
                return NotFound($"Nenhuma música encontrada com o nome '{nome}'.");

            var musicasReq = MapMusicasToActionReq(musicas);

            return Ok(musicasReq);
        }
        catch (Exception ex)
        {
            return BadRequest($"Erro ao buscar música por nome: {ex.Message}");
        }
    }

    [HttpGet("buscar-autor")]
    public async Task<ActionResult<List<MusicaActionReq>>> BuscarMusicaPorAutor(string nomeAutor)
    {
        try
        {
            var musicas = await _playlistApp.RecuperarMusicasPorAutor(nomeAutor);

            if (musicas == null || !musicas.Any())
                return NotFound($"Nenhuma música encontrada para o autor '{nomeAutor}'.");

            var musicasReq = MapMusicasToActionReq(musicas);

            return Ok(musicasReq);
        }
        catch (Exception ex)
        {
            return BadRequest($"Erro ao buscar música por autor: {ex.Message}");
        }
    }
}
