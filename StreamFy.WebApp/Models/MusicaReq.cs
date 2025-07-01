namespace StreamFy.WebApp.Models;

public class MusicaReq
{
    public string Nome { get; set; }
    public int musicaId { get; set; }
    public string ImagemUrl { get; set; }
    public string BandaNome { get; set; } = string.Empty;
    public bool Favorito { get; set; }

    public string EmailUsuario { get; set; }
}