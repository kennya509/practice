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
            // 1. Перетворюємо DTO в сутність бази даних
            var clientEntity = _mapper.Map<Client>(clientDto);

            // 2. Додаємо сутність в репозиторій
            await _unitOfWork.Clients.AddAsync(clientEntity);

            // 3. Зберігаємо зміни в базу даних
            await _unitOfWork.SaveChangesAsync();

            // 4. Перетворюємо створену сутність назад в DTO для відповіді
            var resultDto = _mapper.Map<ClientDto>(clientEntity);
            return resultDto;
        }

        // --- ОСЬ ЦЕЙ МЕТОД ЗМІНЕНО ---
        public async Task<IEnumerable<ClientDto>> GetAllClientsAsync(int pageNumber, int pageSize)
        {
            // 1. Отримуємо всі сутності з бази
            var clientEntities = await _unitOfWork.Clients.GetAllAsync();

            // 2. Застосовуємо пагінацію до отриманого списку
            var pagedClients = clientEntities
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize);

            // 3. Перетворюємо відфільтрований список сутностей в список DTO
            var resultDtos = _mapper.Map<IEnumerable<ClientDto>>(pagedClients);
            return resultDtos;
        }

        public async Task<ClientDto?> GetClientByIdAsync(int id)
        {
            // 1. Отримуємо сутність за ID
            var clientEntity = await _unitOfWork.Clients.GetByIdAsync(id);
            if (clientEntity == null)
            {
                return null; // Повертаємо null, якщо клієнта не знайдено
            }

            // 2. Перетворюємо сутність в DTO
            var resultDto = _mapper.Map<ClientDto>(clientEntity);
            return resultDto;
        }
    }
}