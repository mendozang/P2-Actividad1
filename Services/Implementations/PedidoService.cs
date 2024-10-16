using Domain.Entities;
using Domain.DTO;
using Repositories.Interfaces;
using Services.Interfaces;

namespace Services.Implementations;

public class PedidoService : IPedidoService
{
    private readonly IPedidoRepository _pedidoRepository;
    private readonly IProductoRepository _productoRepository;
    private readonly IUsuarioRepository _usuarioRepository;

    public PedidoService(IPedidoRepository pedidoRepository, IProductoRepository productoRepository, IUsuarioRepository usuarioRepository)
    {
        _pedidoRepository = pedidoRepository;
        _productoRepository = productoRepository;
        _usuarioRepository = usuarioRepository;
    }

    public async Task<IEnumerable<PedidoDto>> GetAllAsync()
    {
        var pedidos = await _pedidoRepository.GetAllAsync();
        return pedidos.Select(p => new PedidoDto
        {
            Id = p.Id,
            UsuarioId = p.UsuarioId,
            Productos = p.Productos?.Select(pr => pr.Id).ToList() ?? new List<int>()
        });
    }

    public async Task<PedidoDto> GetByIdAsync(int id)
    {
        var pedido = await _pedidoRepository.GetByIdAsync(id);
        return new PedidoDto 
        {
            Id = pedido.Id, 
            UsuarioId = pedido.UsuarioId, 
            Productos = pedido.Productos?.Select(pr => pr.Id).ToList() ?? new List<int>()
        };
    }

    public async Task AddAsync(CrearPedidoDto pedidoDto)
    {
        var usuario = await _usuarioRepository.GetByIdAsync(pedidoDto.UsuarioId);
        if (usuario == null)
        {
            throw new Exception("Usuario no encontrado");
        }

        var productos = await _productoRepository.GetByIdsAsync(pedidoDto.Productos);
        if (productos.Count() != pedidoDto.Productos.Count)
        {
            throw new Exception("Algunos productos no fueron encontrados");
        }

        var pedido = new Pedido
        {
            UsuarioId = pedidoDto.UsuarioId,
            Usuario = usuario,
            Productos = productos.ToList()
        };

        await _pedidoRepository.AddAsync(pedido);
    }

    public async Task UpdateAsync(int id, CrearPedidoDto pedidoDto)
    {
        var pedido = await _pedidoRepository.GetByIdAsync(id);
        if (pedido == null)
        {
            throw new Exception("Pedido no encontrado");
        }

        var usuario = await _usuarioRepository.GetByIdAsync(pedidoDto.UsuarioId);
        if (usuario == null)
        {
            throw new Exception("Usuario no encontrado");
        }

        var productos = await _productoRepository.GetByIdsAsync(pedidoDto.Productos);
        if (productos.Count() != pedidoDto.Productos.Count)
        {
            throw new Exception("Algunos productos no fueron encontrados");
        }

        pedido.UsuarioId = pedidoDto.UsuarioId;
        pedido.Usuario = usuario;
        pedido.Productos = productos.ToList();

        await _pedidoRepository.UpdateAsync(pedido);
    }

    public async Task DeleteAsync(int id)
    {
        await _pedidoRepository.DeleteAsync(id);
    }
}