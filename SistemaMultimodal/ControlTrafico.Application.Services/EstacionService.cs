using ControlTrafico.Application.DTO;
using ControlTrafico.Application.Services.Contracts;
using ControlTrafico.Data.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ControlTrafico.Data;
using AutoMapper;
using ControlTrafico.Data.Domain.Entities;

namespace ControlTrafico.Application.Services
{
    public class EstacionService : IEstacionService
    {
        private readonly IMapper _mapper;
        private readonly IEstacionRepository _estacionRepository;

        public EstacionService(IEstacionRepository estacionRepository, IMapper mapper)
        {
            _estacionRepository = estacionRepository;
            _mapper = mapper;
        }

        public async Task<bool> CargarEstaciones(EstacionesRootResponseDto estaciones)
        {
            try
            {
                foreach (var estacionDto in estaciones.ListStation)
                {
                    //TODO FIX MAPPER 
                    var estacionModel = _mapper.Map<Estacion>(estacionDto);
                    await _estacionRepository.AddAsync(estacionModel);
                }
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
