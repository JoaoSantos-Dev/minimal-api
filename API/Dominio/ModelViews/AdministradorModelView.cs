using MinimalAPI.dominio.DTOs.Enums;

namespace MinimalAPI.dominio.ModelViews;

public record AdministradorModelView
{

    public int Id { get; set; }
    public string Email { get; set; } = default!;
    public string Perfil { get; set; } = default!;
}