namespace StreamFy.Core.Modelos;

public class Playlist
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public string Descricao { get; set; }
    
    public List<Musica> Musicas { get; set; }
}