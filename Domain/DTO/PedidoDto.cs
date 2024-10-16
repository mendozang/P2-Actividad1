namespace Domain.DTO;

public class PedidoDto
{
    public int Id { get; set; }
    public int UsuarioId { get; set; }
    public List<int> Productos { get; set; } = null!;
}

public class CrearPedidoDto
{
    public int UsuarioId { get; set; }
    public List<int> Productos { get; set; } = null!;
}