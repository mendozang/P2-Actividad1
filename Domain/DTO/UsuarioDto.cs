namespace Domain.DTO;

public class UsuarioDto
{
    public int Id { get; set; }
    public string Nombre { get; set; } = null!;
    public string Email { get; set; } = null!;
}

public class CrearUsuarioDto
{
    public string Nombre { get; set; } = null!;
    public string Email { get; set; } = null!;
}