using AutoMapper;
using ControlTrafico.Application.DTO;
using ControlTrafico.Data.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
