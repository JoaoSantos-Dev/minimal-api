namespace MinimalAPI.dominio.DTOs;

using MinimalAPI.dominio.DTOs.Enums;

public class AdministradorDTO
{
    public string Email { get; set; } = default!;
    public string Password { get; set; } = default!;
    public Perfil? Perfil { get; set; } = default!;
}