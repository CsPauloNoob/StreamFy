using StreamFy.Core.Enums;
using StreamFy.Core.Modelos;

namespace StreamFy.Core.Fabricas;

public static class FabricaUsuario
{
    public static Usuario CriarUsuario(string nome, string email, string senha)
    {
        //Playlist padrão para todos os usuarios
        var playlist = new Playlist()
        {
            Nome = "Favoritos",
            Descricao = "Playlist de músicas favoritadas"
        };
        
        return new Usuario()
        {
            Nome = nome,
            Email = email,
            Senha = senha,
            Plano = Planos.Free,
            Playlists = [playlist]
        };
    }
}