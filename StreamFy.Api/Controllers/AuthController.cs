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
    public ActionResult<UsuarioReq> Login([FromBody]UsuarioReq usuarioReq)
    {
        try
        {
            var usuario = _usuarioApp.Login(usuarioReq.Email, usuarioReq.Senha);
            var usuarioRes = ConverterParaUsuarioReq(usuario);
            return Ok(usuarioRes);
        }
        catch (Exception ex)
        {
            return BadRequest(new { Message = ex.Message });
        }
    }

    [HttpPost("register")]
    public ActionResult<UsuarioReq> RegistrarUsuario([FromBody]UsuarioReq usuarioReq)
    {
        try
        {
            var usuario = _usuarioApp.RegistrarUsuario(usuarioReq.Nome, usuarioReq.Email, usuarioReq.Senha);
            var usuarioRes = ConverterParaUsuarioReq(usuario);
            return Ok(usuarioRes);
        }
        catch (Exception ex)
        {
            return BadRequest(new { Message = ex.Message });
        }
    }

    private UsuarioReq ConverterParaUsuarioReq(Usuario usuario)
    {
        return new UsuarioReq
        {
            Id = int.TryParse(usuario.Id, out var id) ? id : 0,
            Nome = usuario.Nome,
            Email = usuario.Email,
            Plano = usuario.Plano
            // Não inclua a senha por segurança
        };
    }
}