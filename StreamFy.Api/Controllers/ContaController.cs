using Microsoft.AspNetCore.Mvc;
using StreamFy.Api.RequestModels;
using StreamFy.Application;
using StreamFy.Core.Modelos;

namespace StreamFy.Api.Controllers;

[ApiController]
[Route("conta")]
public class ContaController : ControllerBase
{
    private readonly UsuarioApplication _usuarioApp;

    public ContaController(UsuarioApplication usuarioApplication)
    {
        _usuarioApp = usuarioApplication;
    }

    [HttpPost]
    public ActionResult<string> FavoritarMusica(MusicaActionReq musicaActionReq)
    {
        return Ok();
    }

    [HttpPut]
    public ActionResult<List<string>> UpdatePlano()
    {
        return Ok();
    }
    
}