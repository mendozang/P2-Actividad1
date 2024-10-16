using Domain.DTO;

namespace Services.Interfaces;
public interface IProductoService
{
    Task<IEnumerable<ProductoDto>> GetAllAsync();
    Task<ProductoDto> GetByIdAsync(int id);
    Task AddAsync(CrearProductoDto productoDto);
    Task UpdateAsync(int id, CrearProductoDto productoDto);
    Task DeleteAsync(int id);
}