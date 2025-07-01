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

        if (result.IsSuccessStatusCode)
        {
            var usuarioRegistrado = await result.Content.ReadFromJsonAsync<UsuarioReq>();
            return usuarioRegistrado!;
        }
        else
        {
            // Trate o erro conforme necessário, por exemplo, lançando uma exceção ou retornando null
            throw new Exception("Erro ao registrar usuário: " + result.ReasonPhrase);
        }
    }

    public async Task<UsuarioReq> Login(UsuarioReq usuario)
    {
        var url = _client.BaseAddress + "auth/login";
        var result = await _client.PostAsJsonAsync(url, usuario);

        if (result.IsSuccessStatusCode)
        {
            var usuarioLogado = await result.Content.ReadFromJsonAsync<UsuarioReq>();
            return usuarioLogado!;
        }
        else
        {
            throw new Exception("Erro ao fazer login: " + result.ReasonPhrase);
        }
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