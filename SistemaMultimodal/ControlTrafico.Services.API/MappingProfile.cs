using AutoMapper;
using ControlTrafico.Application.DTO;
using ControlTrafico.Data.Domain.Entities;

namespace ControlTrafico.Services.API
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<FlujoDto, Flujo>();
            CreateMap<Flujo, FlujoDto>();
        }
    }
}
