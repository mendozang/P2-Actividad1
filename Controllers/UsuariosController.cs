using Microsoft.AspNetCore.Mvc;
using Domain.DTO;
using Services.Interfaces;

[ApiController]
[Route("api/[controller]")]
public class UsuariosController : ControllerBase
{
    private readonly IUsuarioService _usuarioService;

    public UsuariosController(IUsuarioService usuarioService)
    {
        _usuarioService = usuarioService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<UsuarioDto>>> GetUsuarios()
    {
        return Ok(await _usuarioService.GetAllAsync());
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<UsuarioDto>> GetUsuario(int id)
    {
        var usuario = await _usuarioService.GetByIdAsync(id);
        if (usuario == null) return NotFound();
        return Ok(usuario);
    }

    [HttpPost]
    public async Task<ActionResult> PostUsuario(CrearUsuarioDto usuarioDto)
    {
        await _usuarioService.AddAsync(usuarioDto);
        return Ok();
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutUsuario(int id, CrearUsuarioDto usuarioDto)
    {
        await _usuarioService.UpdateAsync(id, usuarioDto);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteUsuario(int id)
    {
        await _usuarioService.DeleteAsync(id);
        return NoContent();
    }
}

