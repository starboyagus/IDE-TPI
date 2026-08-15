using Domain.Model;
using Data;
using DTOs;

namespace Application.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository usuarioRepository;

        public UsuarioService(IUsuarioRepository usuarioRepository)
        {
            this.usuarioRepository = usuarioRepository;
        }

        public async Task<UsuarioDTO> AddAsync(UsuarioDTO dto)
        {

            // Validar que el email no esté duplicado
            if (await usuarioRepository.EmailExistsAsync(dto.Email))
            {
                throw new ArgumentException($"Ya existe un usuario con el Email '{dto.Email}'.");
            }

            if (string.IsNullOrWhiteSpace(dto.Contrasenia))
            {
                throw new ArgumentException("La contraseña es obligatoria.");
            }

            var fechaAlta = DateTime.Now;
            // El rol por defecto de todo usuario nuevo es "Usuario"; se ignora lo que venga en el DTO.
            Usuario usuario = new Usuario(0, dto.Nombre, dto.Apellido, dto.Email, dto.Telefono, dto.Contrasenia, RolUsuario.Usuario, fechaAlta, true);

            await usuarioRepository.AddAsync(usuario);

            dto.Id = usuario.Id;
            dto.Rol = usuario.Rol;
            dto.FechaAlta = usuario.FechaAlta;
            dto.EsActivo = usuario.EsActivo;
            dto.Contrasenia = null; // nunca se devuelve la contraseña

            return dto;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await usuarioRepository.DeleteAsync(id);
        }

        public async Task<UsuarioDTO?> GetAsync(int id)
        {
            Usuario? usuario = await usuarioRepository.GetAsync(id);

            if (usuario == null)
                return null;

            return new UsuarioDTO
            {
                Id = usuario.Id,
                Nombre = usuario.Nombre,
                Apellido = usuario.Apellido,
                Email = usuario.Email,
                Telefono = usuario.Telefono,
                Rol = usuario.Rol,
                FechaAlta = usuario.FechaAlta,
                EsActivo = usuario.EsActivo
                // Contrasenia queda sin mapear a propósito: nunca se devuelve por GET.
            };
        }

        public async Task<IEnumerable<UsuarioDTO>> GetAllAsync()
        {
            var usuarios = await usuarioRepository.GetAllAsync();

            return usuarios.Select(usuario => new UsuarioDTO
            {
                Id = usuario.Id,
                Nombre = usuario.Nombre,
                Apellido = usuario.Apellido,
                Email = usuario.Email,
                Telefono = usuario.Telefono,
                Rol = usuario.Rol,
                FechaAlta = usuario.FechaAlta,
                EsActivo = usuario.EsActivo
            }).ToList();
        }

        public async Task<bool> UpdateAsync(UsuarioDTO dto)
        {
            // Validar que el email no esté duplicado (excluyendo el usuario actual)
            if (await usuarioRepository.EmailExistsAsync(dto.Email, dto.Id))
            {
                throw new ArgumentException($"Ya existe otro usuario con el Email '{dto.Email}'.");
            }

            // Obtener el usuario existente para preservar FechaAlta y, si no mandan una nueva, la Contraseña
            var existing = await usuarioRepository.GetAsync(dto.Id);
            if (existing == null)
                return false;

            string contrasenia = string.IsNullOrWhiteSpace(dto.Contrasenia) ? existing.Contrasenia : dto.Contrasenia;

            Usuario usuario = new Usuario(dto.Id, dto.Nombre, dto.Apellido, dto.Email, dto.Telefono, contrasenia, dto.Rol, existing.FechaAlta, dto.EsActivo);
            return await usuarioRepository.UpdateAsync(usuario);
        }

        public async Task<IEnumerable<UsuarioDTO>> GetByCriteriaAsync(UsuarioCriteriaDTO criteriaDTO)
        {
            // Mapear DTO a Domain Model
            var criteria = new UsuarioCriteria(criteriaDTO.Texto);

            // Llamar al repositorio
            var usuarios = await usuarioRepository.GetByCriteriaAsync(criteria);

            // Mapear Domain Model a DTO
            return usuarios.Select(u => new UsuarioDTO
            {
                Id = u.Id,
                Nombre = u.Nombre,
                Apellido = u.Apellido,
                Email = u.Email,
                Telefono = u.Telefono,
                Rol = u.Rol,
                FechaAlta = u.FechaAlta,
                EsActivo = u.EsActivo
            });
        }
    }
}
