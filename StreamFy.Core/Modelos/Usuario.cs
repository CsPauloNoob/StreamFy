using StreamFy.Core.Enums;

namespace StreamFy.Core.Modelos;

public class Usuario
{
    public string Id { get; set; }
    public string Nome { get; set; }
    public string Email { get; set; }
    public string Senha { get; set; }
    public Planos Plano { get; set; }
    
    public List<Playlist> Playlists { get; set; }


    public bool AdicionarMusicaPlaylist(Musica musica, int playlistId)
    {
        var playlist = Playlists.Where(p => p.Id == playlistId).FirstOrDefault();
        
        if (playlist is null) return false;

        else
        {
            playlist.Musicas.Add(musica);
            return true;
        }
    }
}