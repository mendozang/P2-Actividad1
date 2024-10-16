using Microsoft.EntityFrameworkCore;
using Domain.Entities;
using Repositories.Interfaces;
using Data;

namespace Repositories.Implementations;

public class ProductoRepository : IProductoRepository
{
    private readonly AppDbContext _context;

    public ProductoRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Producto>> GetAllAsync() => await _context.Productos.ToListAsync();
    public async Task<Producto> GetByIdAsync(int id) => await _context.Productos.FindAsync(id);
    public async Task<List<Producto>> GetByIdsAsync(List<int> ids) => await _context.Productos.Where(p => ids.Contains(p.Id)).ToListAsync();
    public async Task AddAsync(Producto producto) {_context.Productos.Add(producto); await _context.SaveChangesAsync(); }
    public async Task UpdateAsync(Producto producto) {_context.Productos.Update(producto); await _context.SaveChangesAsync(); }
    public async Task DeleteAsync(int id)
    {
        var producto = await _context.Productos.FindAsync(id);
        if (producto != null) { _context.Productos.Remove(producto); await _context.SaveChangesAsync(); }
    }
}