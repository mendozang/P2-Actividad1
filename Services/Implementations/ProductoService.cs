using Domain.Entities;
using Domain.DTO;
using Repositories.Interfaces;
using Services.Interfaces;

namespace Services.Implementations;

public class ProductoService : IProductoService
{
    private readonly IProductoRepository _productoRepository;

    public ProductoService(IProductoRepository productoRepository)
    {
        _productoRepository = productoRepository;
    }

    public async Task<IEnumerable<ProductoDto>> GetAllAsync()
    {
        var productos = await _productoRepository.GetAllAsync();
        return productos.Select(p => new ProductoDto {Id = p.Id, Nombre = p.Nombre, Precio = p.Precio});
    }

    public async Task<ProductoDto> GetByIdAsync(int id)
    {
        var producto = await _productoRepository.GetByIdAsync(id);
        return new ProductoDto {Id = producto.Id, Nombre = producto.Nombre, Precio = producto.Precio};
    }

    public async Task AddAsync(CrearProductoDto productoDto)
    {
        var producto = new Producto {Nombre = productoDto.Nombre, Precio = productoDto.Precio};
        await _productoRepository.AddAsync(producto);
    }

    public async Task UpdateAsync(int id, CrearProductoDto productoDto)
    {
        var producto = await _productoRepository.GetByIdAsync(id);
        producto.Nombre = productoDto.Nombre;
        producto.Precio = productoDto.Precio;
        await _productoRepository.UpdateAsync(producto);
    }

    public async Task DeleteAsync(int id)
    {
        await _productoRepository.DeleteAsync(id);
    }
}