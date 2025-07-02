using GymMembershipApi.BLL.DTOs;

namespace GymMembershipApi.BLL.Services
{
    public interface IClientService
    {
        Task<IEnumerable<ClientDto>> GetAllClientsAsync(int pageNumber, int pageSize);
        Task<ClientDto?> GetClientByIdAsync(int id);
        Task<ClientDto> CreateClientAsync(CreateClientDto clientDto);
        Task<ClientDto?> UpdateClientAsync(int id, UpdateClientDto updateDto);
        Task<bool> DeleteClientAsync(int id);
    }
}