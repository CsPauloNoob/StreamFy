using Microsoft.AspNetCore.Mvc;
using StreamFy.Api.RequestModels;
using StreamFy.Application;
using StreamFy.Core.Modelos;

namespace StreamFy.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class ContaController : ControllerBase
{
    private readonly UsuarioApplication _usuarioApp;


    public ContaController(UsuarioApplication usuarioApplication)
    {
        _usuarioApp = usuarioApplication;
    }

    [HttpPost]
    public ActionResult<Usuario> Login(UsuarioReq usuarioReq)
    {
        var usuario = _usuarioApp.Login(usuarioReq.email, usuarioReq.senha);
        
        return Ok(usuario);
    }
}