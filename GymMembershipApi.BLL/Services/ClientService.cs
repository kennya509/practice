using AutoMapper;
using GymMembershipApi.BLL.Services;
using GymMembershipApi.DAL.Repositories;
using GymMembershipApi.BLL.DTOs;
using GymMembershipApi.DAL.Entities;

namespace GymMembershipApi.BLL.Implementations // Важливо! Я змінив namespace
{
    public class ClientService : IClientService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ClientService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ClientDto> CreateClientAsync(CreateClientDto clientDto)
        {
            var client = _mapper.Map<Client>(clientDto);
            await _unitOfWork.Clients.AddAsync(client);
            await _unitOfWork.SaveChangesAsync();
            return _mapper.Map<ClientDto>(client);
        }

        public async Task<IEnumerable<ClientDto>> GetAllClientsAsync(int pageNumber, int pageSize)
        {
            var clients = await _unitOfWork.Clients.GetAllAsync();
            var pagedClients = clients.Skip((pageNumber - 1) * pageSize).Take(pageSize);
            return _mapper.Map<IEnumerable<ClientDto>>(pagedClients);
        }

        public async Task<ClientDto?> GetClientByIdAsync(int id)
        {
            var client = await _unitOfWork.Clients.GetByIdAsync(id);
            return _mapper.Map<ClientDto>(client);
        }
        public async Task<ClientDto?> UpdateClientAsync(int id, UpdateClientDto updateDto)
        {
            var client = await _unitOfWork.Clients.GetByIdAsync(id);
            if (client == null) return null;

            
            client.FirstName = updateDto.FirstName;
            client.LastName = updateDto.LastName;
            client.PhoneNumber = updateDto.PhoneNumber;

            _unitOfWork.Clients.Update(client);
            await _unitOfWork.SaveChangesAsync();

            return _mapper.Map<ClientDto>(client);
        }

        public async Task<bool> DeleteClientAsync(int id)
        {
            var client = await _unitOfWork.Clients.GetByIdAsync(id);
            if (client == null) return false;

            _unitOfWork.Clients.Delete(client);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }
    }
}