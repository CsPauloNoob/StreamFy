using StreamFy.Core.Enums;

namespace StreamFy.Api.RequestModels;

public class UsuarioReq
{
    public int Id { get; set; }

    public string Email { get; set; }

    public string Senha { get; set; }

    public string? Nome { get; set; }

    public Planos Plano { get; set; }
}