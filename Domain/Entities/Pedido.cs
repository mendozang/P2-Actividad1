namespace Domain.Entities;

public class Pedido
{
    public int Id { get; set; }
    public int UsuarioId { get; set; }
    public required Usuario Usuario { get; set; }
    public required List<Producto> Productos { get; set; }
}