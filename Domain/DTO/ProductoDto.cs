namespace Domain.DTO;

public class ProductoDto
{
    public int Id { get; set; }
    public string Nombre { get; set; } = null!;
    public decimal Precio { get; set; }
}

public class CrearProductoDto
{
    public string Nombre { get; set; } = null!;
    public decimal Precio { get; set; }
}