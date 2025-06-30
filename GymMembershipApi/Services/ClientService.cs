using AutoMapper;
using GymMembershipApi.DTOs;
using GymMembershipApi.Entities;
using GymMembershipApi.Repositories;

namespace GymMembershipApi.Services
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
            var clientEntity = _mapper.Map<Client>(clientDto);

            await _unitOfWork.Clients.AddAsync(clientEntity);

            await _unitOfWork.SaveChangesAsync();

            var resultDto = _mapper.Map<ClientDto>(clientEntity);
            return resultDto;
        }

        public async Task<IEnumerable<ClientDto>> GetAllClientsAsync(int pageNumber, int pageSize)
        {
            var clientEntities = await _unitOfWork.Clients.GetAllAsync();

            var pagedClients = clientEntities
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize);

            var resultDtos = _mapper.Map<IEnumerable<ClientDto>>(pagedClients);
            return resultDtos;
        }

        public async Task<ClientDto?> GetClientByIdAsync(int id)
        {
            var clientEntity = await _unitOfWork.Clients.GetByIdAsync(id);
            if (clientEntity == null)
            {
                return null; 
            }

            var resultDto = _mapper.Map<ClientDto>(clientEntity);
            return resultDto;
        }
        public async Task<ClientDto?> UpdateClientAsync(int id, CreateClientDto clientDto)
        {
            var existingClient = await _unitOfWork.Clients.GetByIdAsync(id);

            if (existingClient == null)
            {
                return null;
            }

            
            _mapper.Map(clientDto, existingClient);

            _unitOfWork.Clients.Update(existingClient);

            await _unitOfWork.SaveChangesAsync();

            return _mapper.Map<ClientDto>(existingClient);
        }
    }
}