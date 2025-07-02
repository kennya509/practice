using AutoMapper;
using GymMembershipApi.BLL.DTOs;
using GymMembershipApi.DAL.Entities;

namespace GymMembershipApi.BLL.Mappings;

    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
           
            CreateMap<Client, ClientDto>()
                .ForMember(dest => dest.FullName,
                           opt => opt.MapFrom(src => $"{src.FirstName} {src.LastName}"));

           
            CreateMap<CreateClientDto, Client>();
        }
    }
