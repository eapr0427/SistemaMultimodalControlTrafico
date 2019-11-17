using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ControlTrafico.Application.DTO;
using ControlTrafico.Data.Domain.Entities;
using AutoMapper;

namespace ControlTrafico.Presentation.Admin
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Estacion, EstacionesResponseDTO>();
            CreateMap<FlujoDto, Flujo>();
            CreateMap<RutaDisponibleDTO, RutasDisponibles>();
            CreateMap<RutasDisponibles, RutaDisponibleDTO>();
            CreateMap<Flujo, FlujoDto>();
        }
    }
}
