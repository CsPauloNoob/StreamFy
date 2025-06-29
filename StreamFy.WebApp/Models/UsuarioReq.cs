using System.ComponentModel.DataAnnotations;

namespace StreamFy.WebApp.Models;

public class UsuarioReq
{
    public int Id { get; set; }
    
    public string Email { get; set; }
    
    public string Senha { get; set; }
    
    public string? Nome { get; set; }
}