using Microsoft.EntityFrameworkCore;
using Domain.Entities;
using Repositories.Interfaces;
using Data;

namespace Repositories.Implementations;

public class PedidoRepository : IPedidoRepository
{
    private readonly AppDbContext _context;

    public PedidoRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Pedido>> GetAllAsync() => await _context.Pedidos.Include(p => p.Productos).ToListAsync();
    public async Task<Pedido> GetByIdAsync(int id) => await _context.Pedidos.Include(p => p.Productos).FirstOrDefaultAsync(p => p.Id == id);
    public async Task AddAsync(Pedido pedido) {_context.Pedidos.Add(pedido); await _context.SaveChangesAsync(); }
    public async Task UpdateAsync(Pedido pedido) {_context.Pedidos.Update(pedido); await _context.SaveChangesAsync(); }
    public async Task DeleteAsync(int id)
    {
        var pedido = await _context.Pedidos.FindAsync(id);
        if (pedido != null) { _context.Pedidos.Remove(pedido); await _context.SaveChangesAsync(); }
    }
}