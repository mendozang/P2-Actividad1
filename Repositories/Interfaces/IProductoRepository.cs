using Domain.Entities;

namespace Repositories.Interfaces;
public interface IProductoRepository
{
    Task<IEnumerable<Producto>> GetAllAsync();
    Task<Producto> GetByIdAsync(int id);
    Task<List<Producto>> GetByIdsAsync(List<int> ids);
    Task AddAsync(Producto producto);
    Task UpdateAsync(Producto producto);
    Task DeleteAsync(int id);
}