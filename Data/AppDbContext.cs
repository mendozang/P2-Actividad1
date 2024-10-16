using Microsoft.EntityFrameworkCore;
using Domain.Entities;

namespace Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) {}
    public DbSet<Usuario> Usuarios { get; set; } = null!;
    public DbSet<Producto> Productos { get; set; } = null!;
    public DbSet<Pedido> Pedidos { get; set; } = null!;
}