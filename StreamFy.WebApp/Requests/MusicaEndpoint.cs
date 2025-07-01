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
        var url = _client.BaseAddress + "musica?quantidade="+ quantidade;
        var result = await _client.GetFromJsonAsync<List<MusicaReq>>(url);

        result.ForEach(m =>
        {
            m.ImagemUrl = m.ImagemUrl ?? "/images/image1.jpg";
        });

        return result ?? new List<MusicaReq>();
    }

    public async Task<bool> FavoritarMusica(MusicaReq musica)
    {
        return true;
    }

    public async Task<List<MusicaReq>> BuscarMusica(string textoBusca)
    {
        var finalList = new List<MusicaReq>();

        try
        {
            var url = _client.BaseAddress + "musica/buscar?nome=" + textoBusca;
            var result = await _client.GetFromJsonAsync<List<MusicaReq>>(url) ?? new List<MusicaReq>();
            finalList.AddRange(result);
        }

        catch (Exception ex)
        {
            // Log exception or handle it as needed  
            Console.WriteLine($"Erro ao buscar músicas: {ex.Message}");
        }

        try
        {
            var url2 = _client.BaseAddress + "musica/buscar-autor?nomeAutor=" + textoBusca;
            var result2 = await _client.GetFromJsonAsync<List<MusicaReq>>(url2) ?? new List<MusicaReq>();
            finalList.AddRange(result2);
        }
        catch (Exception ex)
        {
            // Log exception or handle it as needed  
            Console.WriteLine($"Erro ao buscar músicas por autor: {ex.Message}");
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
}