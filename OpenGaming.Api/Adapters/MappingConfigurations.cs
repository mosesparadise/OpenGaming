using AutoMapper;
using OpenGaming.Api.Infrastructure.Entities;
using OpenGaming.Api.Model;

namespace OpenGaming.Api.Adapters;

public class MappingConfigurations : Profile
{
    public MappingConfigurations()
    {
        CreateMap<Punter, AddPunterRequestDto>().ReverseMap();
        CreateMap<Punter, AddPunterResponseDto>().ReverseMap();
        CreateMap<Punter, PunterRequestDto>().ReverseMap();
        CreateMap<Punter, PunterResponseDto>().ReverseMap();
        CreateMap<Event, AddEventResponseDto>().ReverseMap();
        CreateMap<Event, AddEventRequestDto>().ReverseMap();
        CreateMap<Event, EventRequestDto>().ReverseMap();
        CreateMap<Event, EventResponseDto>().ReverseMap();
    }
}