using Microsoft.AspNetCore.Mvc;
using Domain.DTO;
using Services.Interfaces;

[ApiController]
[Route("api/[controller]")]
public class ProductosController : ControllerBase
{
    private readonly IProductoService _productoService;

    public ProductosController(IProductoService productoService)
    {
        _productoService = productoService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<ProductoDto>>> GetProductos()
    {
        return Ok(await _productoService.GetAllAsync());
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ProductoDto>> GetProducto(int id)
    {
        var producto = await _productoService.GetByIdAsync(id);
        if (producto == null) return NotFound();
        return Ok(producto);
    }

    [HttpPost]
    public async Task<ActionResult> PostProducto(CrearProductoDto productoDto)
    {
        await _productoService.AddAsync(productoDto);
        return Ok();
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutProducto(int id, CrearProductoDto productoDto)
    {
        await _productoService.UpdateAsync(id, productoDto);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteProducto(int id)
    {
        await _productoService.DeleteAsync(id);
        return NoContent();
    }
}