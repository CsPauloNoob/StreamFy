

using StreamFy.Core.Modelos;
using StreamFy.Core.Fabricas;

namespace StreamFy.Application;

public class UsuarioApplication
{
    public UsuarioApplication()
    {
        
    }

    public Usuario RegistrarUsuario(string nome, string email, string senha)
    {
        var usuario = FabricaUsuario.CriarUsuario(nome, email, senha);
        
        return usuario;
    }
    
    public Usuario Login(string email, string senha)
    {
        return new();
    }
}