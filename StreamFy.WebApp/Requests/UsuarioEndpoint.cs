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
        int maxTentativas = 2;

        for (int tentativa = 1; tentativa <= maxTentativas; tentativa++)
        {
            try
            {
                var result = await _client.PostAsJsonAsync(url, usuario);

                if (result.IsSuccessStatusCode)
                {
                    var usuarioRegistrado = new UsuarioReq()
                    {
                        Id = 0,
                        Email = usuario.Email,
                        Senha = usuario.Senha,
                        Nome = usuario.Nome,
                        Plano = Planos.Free, // Definindo plano padrão como Free
                    };
                    return usuarioRegistrado!;
                }
                else
                {
                    throw new Exception("Erro ao registrar usuário: " + result.ReasonPhrase);
                }
            }
            catch (Exception ex)
            {
                if (tentativa == maxTentativas)
                    throw new Exception($"Erro ao registrar usuário: {ex.Message}");
                await Task.Delay(2000);
            }
        }
        throw new Exception("Erro desconhecido ao registrar usuário.");
    }

    public async Task<UsuarioReq> Login(UsuarioReq usuario)
    {
        var url = _client.BaseAddress + "auth/login";
        int maxTentativas = 2;

        for (int tentativa = 1; tentativa <= maxTentativas; tentativa++)
        {
            try
            {
                var result = await _client.PostAsJsonAsync(url, usuario);

                if (result.IsSuccessStatusCode)
                {
                    var usuarioRegistrado = new UsuarioReq()
                    {
                        Id = 0,
                        Email = usuario.Email,
                        Senha = usuario.Senha,
                        Nome = usuario.Nome,
                        Plano = Planos.Free, // Definindo plano padrão como Free
                    };
                    return usuarioRegistrado!;
                }
                else
                {
                    throw new Exception("Erro ao fazer login: " + result.ReasonPhrase);
                }
            }
            catch (Exception ex)
            {
                if (tentativa == maxTentativas)
                    throw new Exception($"Erro ao fazer login: {ex.Message}");
                await Task.Delay(2000);
            }
        }
        throw new Exception("Erro desconhecido ao fazer login.");
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