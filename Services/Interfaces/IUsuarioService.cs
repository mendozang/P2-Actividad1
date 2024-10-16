using Domain.DTO;

namespace Services.Interfaces;
public interface IUsuarioService
{
    Task<IEnumerable<UsuarioDto>> GetAllAsync();
    Task<UsuarioDto> GetByIdAsync(int id);
    Task AddAsync(CrearUsuarioDto usuarioDto);
    Task UpdateAsync(int id, CrearUsuarioDto usuarioDto);
    Task DeleteAsync(int id);
}