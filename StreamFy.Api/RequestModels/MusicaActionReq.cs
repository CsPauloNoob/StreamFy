namespace StreamFy.Api.RequestModels;

public class MusicaActionReq
{
    public string Nome { get; set; }
    public int musicaId { get; set; }
    public string BandaNome { get; set; } = string.Empty;
    public int PlaylistId { get; set; }
    public bool Favorito { get; set; }
    
}