using StreamFy.WebApp.Models;
using System.Net.Http.Json;

namespace StreamFy.WebApp.Requests;

public class MusicaEndpoint
{
    private readonly HttpClient _client;

    public MusicaEndpoint(HttpClient client)
    {
        _client = client;
    }


    public async Task<List<MusicaReq>> GetMusicas(int quantidade = 8)
    {
        int maxTentativas = 2;
        for (int tentativa = 1; tentativa <= maxTentativas; tentativa++)
        {
            try
            {
                var url = _client.BaseAddress + "musica?quantidade=" + quantidade;
                var result = await _client.GetFromJsonAsync<List<MusicaReq>>(url);

                result?.ForEach(m =>
                {
                    m.ImagemUrl = m.ImagemUrl ?? "/images/image1.jpg";
                });

                return result ?? new List<MusicaReq>();
            }
            catch (Exception ex)
            {
                if (tentativa == maxTentativas)
                {
                    Console.WriteLine($"Erro ao buscar músicas: {ex.Message}");
                    return new List<MusicaReq>();
                }
                
                await Task.Delay(2000);
            }
        }
        return new List<MusicaReq>();
    }



    public async Task<bool> FavoritarMusica(MusicaReq musica)
    {
        int maxTentativas = 2;
        for (int tentativa = 1; tentativa <= maxTentativas; tentativa++)
        {
            try
            {
                
                var url = _client.BaseAddress + "musica/favoritar";
                url += $"?email={Uri.EscapeDataString(UsuarioLogado.usuarioLogadoInfo.Email)}";

                var response = await _client.PostAsJsonAsync(url, musica);

                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                if (tentativa == maxTentativas)
                {
                    Console.WriteLine($"Erro ao favoritar música: {ex.Message}");
                    return false;
                }
                await Task.Delay(2000);
            }
        }
        return false;
    }

    public async Task<List<MusicaReq>> BuscarMusica(string textoBusca)
    {
        var finalList = new List<MusicaReq>();
        int maxTentativas = 2;

        // Buscar por nome da música
        for (int tentativa = 1; tentativa <= maxTentativas; tentativa++)
        {
            try
            {
                var url = _client.BaseAddress + "musica/buscar?nome=" + textoBusca;
                var result = await _client.GetFromJsonAsync<List<MusicaReq>>(url) ?? new List<MusicaReq>();
                finalList.AddRange(result);
                break;
            }
            catch (Exception ex)
            {
                if (tentativa == maxTentativas)
                    Console.WriteLine($"Erro ao buscar músicas: {ex.Message}");
                else
                    await Task.Delay(2000);
            }
        }

        // Buscar por nome do autor
        for (int tentativa = 1; tentativa <= maxTentativas; tentativa++)
        {
            try
            {
                var url2 = _client.BaseAddress + "musica/buscar-autor?nomeAutor=" + textoBusca;
                var result2 = await _client.GetFromJsonAsync<List<MusicaReq>>(url2) ?? new List<MusicaReq>();
                finalList.AddRange(result2);
                break;
            }
            catch (Exception ex)
            {
                if (tentativa == maxTentativas)
                    Console.WriteLine($"Erro ao buscar músicas por autor: {ex.Message}");
                else
                    await Task.Delay(2000);
            }
        }

        finalList = finalList
            .GroupBy(m => m.musicaId)
            .Select(g => g.First())
            .ToList();

        finalList.ForEach(m =>
        {
            m.ImagemUrl = m.ImagemUrl ?? "/images/image1.jpg";
        });

        return finalList;
    }


    public async Task<List<AutorReq>> GetAutor()
    {
        int maxTentativas = 2;
        for (int tentativa = 1; tentativa <= maxTentativas; tentativa++)
        {
            try
            {
                var url = _client.BaseAddress + "autor";
                var result = await _client.GetFromJsonAsync<List<AutorReq>>(url);
                return result ?? new List<AutorReq>();
            }
            catch (Exception ex)
            {
                if (tentativa == maxTentativas)
                {
                    Console.WriteLine($"Erro ao buscar autores: {ex.Message}");
                    return new List<AutorReq>();
                }

                await Task.Delay(2000);
            }
        }
        return new List<AutorReq>();
    }

}