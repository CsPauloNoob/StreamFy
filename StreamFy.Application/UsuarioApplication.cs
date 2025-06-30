

using StreamFy.Core.Modelos;
using StreamFy.Core.Fabricas;
using StreamFy.Core.Interfaces;

namespace StreamFy.Application;

public class UsuarioApplication
{
    private readonly IUsuarioRepository _usuarioRepo;

    public UsuarioApplication(IUsuarioRepository usuarioRepository)
    {
        _usuarioRepo = usuarioRepository;
    }

    public Usuario RegistrarUsuario(string nome, string email, string senha)
    {
        var usuario = FabricaUsuario.CriarUsuario(nome, email, senha);

        _usuarioRepo.AdicionarAsync(usuario)
            .GetAwaiter()
            .GetResult();

        return usuario;
    }
    
    public Usuario Login(string email, string senha)
    {
        return new();
    }
}