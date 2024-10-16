using Domain.DTO;

namespace Services.Interfaces;
public interface IPedidoService
{
    Task<IEnumerable<PedidoDto>> GetAllAsync();
    Task<PedidoDto> GetByIdAsync(int id);
    Task AddAsync(CrearPedidoDto pedidoDto);
    Task UpdateAsync(int id, CrearPedidoDto pedidoDto);
    Task DeleteAsync(int id);
}