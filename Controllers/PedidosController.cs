using Microsoft.AspNetCore.Mvc;
using Domain.DTO;
using Services.Interfaces;

[ApiController]
[Route("api/[controller]")]
public class PedidosController : ControllerBase
{
    private readonly IPedidoService _pedidoService;

    public PedidosController(IPedidoService pedidoService)
    {
        _pedidoService = pedidoService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<PedidoDto>>> GetPedidos()
    {
        return Ok(await _pedidoService.GetAllAsync());
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<PedidoDto>> GetPedido(int id)
    {
        var pedido = await _pedidoService.GetByIdAsync(id);
        if (pedido == null) return NotFound();
        return Ok(pedido);
    }

    [HttpPost]
    public async Task<ActionResult> PostPedido(CrearPedidoDto pedidoDto)
    {
        await _pedidoService.AddAsync(pedidoDto);
        return Ok();
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutPedido(int id, CrearPedidoDto pedidoDto)
    {
        await _pedidoService.UpdateAsync(id, pedidoDto);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeletePedido(int id)
    {
        await _pedidoService.DeleteAsync(id);
        return NoContent();
    }
}