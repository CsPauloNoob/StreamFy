namespace StreamFy.Core.Modelos;

public class Playlist
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public string Descricao { get; set; }

    public List<Musica> Musicas { get; set; } = new();


    public bool AdicionarMusica(Musica musica)
    {
        if(Musicas.Any(x => x.Id == musica.Id))
            return false;

        else
        {
            Musicas.Add(musica);
            return true;
        }
    }
}