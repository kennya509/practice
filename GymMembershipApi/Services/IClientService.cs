using GymMembershipApi.DTOs;

namespace GymMembershipApi.Services
{
    public interface IClientService
    {
        Task<IEnumerable<ClientDto>> GetAllClientsAsync(int pageNumber, int pageSize);
        Task<ClientDto?> GetClientByIdAsync(int id);
        Task<ClientDto> CreateClientAsync(CreateClientDto clientDto);
    }
}