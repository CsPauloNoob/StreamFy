using StreamFy.WebApp.Models;

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
        List<MusicaReq> _musicas = new()
        {
            new MusicaReq { Nome = "Musica 1", ImagemUrl = "images/image1.jpg" },
            new MusicaReq { Nome = "Musica 2", ImagemUrl = "images/image1.jpg" },
            new MusicaReq { Nome = "Musica 3", ImagemUrl = "images/image1.jpg" },
            new MusicaReq { Nome = "Musica 4", ImagemUrl = "images/image1.jpg" },
            new MusicaReq { Nome = "Musica 5", ImagemUrl = "images/image1.jpg" },
            new MusicaReq { Nome = "Musica 6", ImagemUrl = "images/image1.jpg" }
        };
        
        return _musicas;
    }
}