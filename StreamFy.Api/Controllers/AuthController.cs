using Microsoft.AspNetCore.Mvc;
using StreamFy.Api.RequestModels;
using StreamFy.Application;
using StreamFy.Core.Modelos;

namespace StreamFy.Api.Controllers;

[ApiController]
[Route("auth")]
public class AuthController : ControllerBase
{
    private readonly UsuarioApplication _usuarioApp;

    public AuthController(UsuarioApplication usuarioApplication)
    {
        _usuarioApp = usuarioApplication;
    }
    
    
    
    [HttpPost("login")]
    public ActionResult<Usuario> Login(UsuarioReq usuarioReq)
    {
        var usuario = _usuarioApp.Login(usuarioReq.Email, usuarioReq.Senha);
        
        return Ok(usuario);
    }
}