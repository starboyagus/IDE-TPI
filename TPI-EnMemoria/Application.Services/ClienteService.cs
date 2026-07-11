using Domain.Model;
using Data;
using DTOs;

namespace Application.Services
{
    public class ClienteService : IClienteService
    {
        private readonly IClienteRepository clienteRepository;

        public ClienteService(IClienteRepository clienteRepository)
        {
            this.clienteRepository = clienteRepository;
        }

        public async Task<ClienteDTO> AddAsync(ClienteDTO dto)
        {

            // Validar que el email no esté duplicado
            if (await clienteRepository.EmailExistsAsync(dto.Email))
            {
                throw new ArgumentException($"Ya existe un cliente con el Email '{dto.Email}'.");
            }

            var fechaAlta = DateTime.Now;
            Cliente cliente = new Cliente(0, dto.Nombre, dto.Apellido, dto.Email, fechaAlta);

            await clienteRepository.AddAsync(cliente);

            dto.Id = cliente.Id;
            dto.FechaAlta = cliente.FechaAlta;

            return dto;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await clienteRepository.DeleteAsync(id);
        }

        public async Task<ClienteDTO?> GetAsync(int id)
        {
            Cliente? cliente = await clienteRepository.GetAsync(id);

            if (cliente == null)
                return null;

            return new ClienteDTO
            {
                Id = cliente.Id,
                Nombre = cliente.Nombre,
                Apellido = cliente.Apellido,
                Email = cliente.Email,
                FechaAlta = cliente.FechaAlta
            };
        }

        public async Task<IEnumerable<ClienteDTO>> GetAllAsync()
        {
            var clientes = await clienteRepository.GetAllAsync();

            return clientes.Select(cliente => new ClienteDTO
            {
                Id = cliente.Id,
                Nombre = cliente.Nombre,
                Apellido = cliente.Apellido,
                Email = cliente.Email,
                FechaAlta = cliente.FechaAlta
            }).ToList();
        }

        public async Task<bool> UpdateAsync(ClienteDTO dto)
        {
            // Validar que el email no esté duplicado (excluyendo el cliente actual)
            if (await clienteRepository.EmailExistsAsync(dto.Email, dto.Id))
            {
                throw new ArgumentException($"Ya existe otro cliente con el Email '{dto.Email}'.");
            }

            // Obtener el cliente existente para preservar FechaAlta
            var existing = await clienteRepository.GetAsync(dto.Id);
            if (existing == null)
                return false;

            Cliente cliente = new Cliente(dto.Id, dto.Nombre, dto.Apellido, dto.Email, existing.FechaAlta);
            return await clienteRepository.UpdateAsync(cliente);
        }

        public async Task<IEnumerable<ClienteDTO>> GetByCriteriaAsync(ClienteCriteriaDTO criteriaDTO)
        {
            // Mapear DTO a Domain Model
            var criteria = new ClienteCriteria(criteriaDTO.Texto);

            // Llamar al repositorio
            var clientes = await clienteRepository.GetByCriteriaAsync(criteria);

            // Mapear Domain Model a DTO
            return clientes.Select(c => new ClienteDTO
            {
                Id = c.Id,
                Nombre = c.Nombre,
                Apellido = c.Apellido,
                Email = c.Email,
                FechaAlta = c.FechaAlta
            });
        }
    }
}
