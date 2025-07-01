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


    public async Task<List<MusicaReq>> GetMusicas(int quantidade = 5)
    {
        var url = _client.BaseAddress + "musica?quantidade="+5;
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
        var url = _client.BaseAddress + "musica/buscar?nome=" + textoBusca;
        var url2 = _client.BaseAddress + "musica/buscar-autor?nomeAutor=" + textoBusca;

        var result = await _client.GetFromJsonAsync<List<MusicaReq>>(url) ?? new List<MusicaReq>();
        var result2 = await _client.GetFromJsonAsync<List<MusicaReq>>(url2) ?? new List<MusicaReq>();

        var finalList = result
    .Concat(result2)
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