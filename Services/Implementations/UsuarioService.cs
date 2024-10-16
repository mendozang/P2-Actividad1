using Domain.DTO;
using Repositories.Interfaces;
using Domain.Entities;
using Services.Interfaces;

namespace Services.Implementations;

public class UsuarioService : IUsuarioService
{
    private readonly IUsuarioRepository _usuarioRepository;

    public UsuarioService(IUsuarioRepository usuarioRepository)
    {
        _usuarioRepository = usuarioRepository;
    }

    public async Task<IEnumerable<UsuarioDto>> GetAllAsync()
    {
        var usuarios = await _usuarioRepository.GetAllAsync();
        return usuarios.Select(u => new UsuarioDto {Id = u.Id, Nombre = u.Nombre, Email = u.Email});
    }

    public async Task<UsuarioDto> GetByIdAsync(int id)
    {
        var usuario = await _usuarioRepository.GetByIdAsync(id);
        return new UsuarioDto {Id = usuario.Id, Nombre = usuario.Nombre, Email = usuario.Email};
    }

    public async Task AddAsync(CrearUsuarioDto usuarioDto)
    {
        var usuario = new Usuario {Nombre = usuarioDto.Nombre, Email = usuarioDto.Email};
        await _usuarioRepository.AddAsync(usuario);
    }

    public async Task UpdateAsync(int id, CrearUsuarioDto usuarioDto)
    {
        var usuario = await _usuarioRepository.GetByIdAsync(id);
        usuario.Nombre = usuarioDto.Nombre;
        usuario.Email = usuarioDto.Email;
        await _usuarioRepository.UpdateAsync(usuario);
    }

    public async Task DeleteAsync(int id)
    {
        await _usuarioRepository.DeleteAsync(id);
    }
}