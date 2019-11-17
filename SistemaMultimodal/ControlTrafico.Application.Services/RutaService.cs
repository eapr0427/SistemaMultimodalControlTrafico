using AutoMapper;
using ControlTrafico.Application.DTO;
using ControlTrafico.Data.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlTrafico.Application.Services
{
    public class RutaService : IRutaService
    {
        private readonly IMapper _mapper;
        private readonly IRutasRepository _rutaRepository;
        public RutaService(IRutasRepository rutaRepository, IMapper mapper)
        {
            _rutaRepository = rutaRepository;
            _mapper = mapper;
        }
        public async Task<IEnumerable<RutaDisponibleDTO>> GetRutasDisponibles()
        {
            try
            {
                var rutasDisponibles = await _rutaRepository.GetRutasDisponibles();
                List<RutaDisponibleDTO> rutaDisponiblesDtos = new List<RutaDisponibleDTO>();
                foreach (var rutas in rutasDisponibles)
                {
                    var rutaDisponibleDTO = _mapper.Map<RutaDisponibleDTO>(rutas);
                    rutaDisponiblesDtos.Add(rutaDisponibleDTO);
                    //TODO CONSUMIR SERVICIO MARIO E INSERTAR EN FLUJO, LA RUTA QUE MARIO ME ENVÍE


                    //TODO INSERTAR TABLA FLUJO


                }
                return rutaDisponiblesDtos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
