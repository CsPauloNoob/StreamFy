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

    [HttpPost("favoritar")]
    public async Task<ActionResult> AdicionarMusicaPlaylist([FromBody]MusicaActionReq actionReq, [FromQuery] string email)
    {
        try
        {
            await _playlistApp.FavoritarMusica(new Musica
            {
                Id = actionReq.musicaId,
                Nome = actionReq.Nome,
            }, email);

            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest($"Erro ao favoritar musica {ex.Message}");
        }
    }

    [HttpGet]
    public ActionResult<List<MusicaActionReq>> GetMusicas(int quantidade)
    {
        try
        {
            var musicas = _playlistApp.RecuperarMusicas(quantidade);

            if (musicas == null || !musicas.Any())
                return NotFound("Nenhuma m�sica encontrada.");

            var musicasReq = MapMusicasToActionReq(musicas);

            return Ok(musicasReq);
        }
        catch (Exception ex)
        {
            return BadRequest($"Erro ao recuperar m�sicas: {ex.Message}");
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
                return NotFound($"Nenhuma m�sica encontrada com o nome '{nome}'.");

            var musicasReq = MapMusicasToActionReq(musicas);

            return Ok(musicasReq);
        }
        catch (Exception ex)
        {
            return BadRequest($"Erro ao buscar m�sica por nome: {ex.Message}");
        }
    }

    [HttpGet("buscar-autor")]
    public async Task<ActionResult<List<MusicaActionReq>>> BuscarMusicaPorAutor(string nomeAutor)
    {
        try
        {
            var musicas = await _playlistApp.RecuperarMusicasPorAutor(nomeAutor);

            if (musicas == null || !musicas.Any())
                return NotFound($"Nenhuma m�sica encontrada para o autor '{nomeAutor}'.");

            var musicasReq = MapMusicasToActionReq(musicas);

            return Ok(musicasReq);
        }
        catch (Exception ex)
        {
            return BadRequest($"Erro ao buscar m�sica por autor: {ex.Message}");
        }
    }
}
