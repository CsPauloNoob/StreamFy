using MudBlazor.Extensions;
using StreamFy.WebApp.Models;
using System.Net.Http.Json;

namespace StreamFy.WebApp.Requests;

public class UsuarioEndpoint
{
    private readonly HttpClient _client;

    public UsuarioEndpoint(HttpClient client)
    {
        _client = client;
    }

    public async Task<UsuarioReq> RegistrarUsuario(UsuarioReq usuario)
    {
        var url = _client.BaseAddress + "auth/register";
        var result = await _client.PostAsJsonAsync(url, usuario);

        return result.Content.As<UsuarioReq>();
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