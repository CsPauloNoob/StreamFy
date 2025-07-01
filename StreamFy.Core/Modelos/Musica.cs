namespace StreamFy.Core.Modelos;

public class Musica
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public int AutorId { get; set; }
    public Autor Autor { get; set; }

}