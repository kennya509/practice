using AutoMapper;
using GymMembershipApi.DTOs;
using GymMembershipApi.Entities;

namespace GymMembershipApi.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Мапінг з Client (Entity) в ClientDto
            CreateMap<Client, ClientDto>()
                .ForMember(dest => dest.FullName,
                           opt => opt.MapFrom(src => $"{src.FirstName} {src.LastName}"));

            // Мапінг з CreateClientDto в Client (Entity)
            CreateMap<CreateClientDto, Client>();
        }
    }
}