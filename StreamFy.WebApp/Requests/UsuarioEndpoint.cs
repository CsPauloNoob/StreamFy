using StreamFy.WebApp.Models;

namespace StreamFy.WebApp.Requests;

public class UsuarioEndpoint
{
    private readonly HttpClient _client;

    public UsuarioEndpoint()
    {
        _client = new HttpClient();
        _client.BaseAddress = new Uri("http://localhost:5000");
    }

    public async Task<UsuarioReq> RegistrarUsuario(UsuarioReq usuario)
    {
        return new UsuarioReq()
        {
            Id = 123123,
            Email = usuario.Email,
            Senha = usuario.Senha,
            Nome = usuario.Nome,
            Plano = usuario.Plano,
        };
    }

    public async Task<UsuarioReq> Login(UsuarioReq usuario)
    {
        return new UsuarioReq()
        {
            Id = 123123,
            Email = usuario.Email,
            Senha = usuario.Senha,
            Nome = usuario.Nome,
        };
    }

    public async Task<UsuarioReq> AlterarPlano(UsuarioReq usuario, Planos novoPlano)
    {
        return new UsuarioReq()
        {
            Id = 123123,
            Email = usuario.Email,
            Senha = usuario.Senha,
            Nome = usuario.Nome,
            Plano = novoPlano,
        };
    }
    
}