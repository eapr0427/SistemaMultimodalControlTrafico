using AutoMapper;
using ControlTrafico.Application.DTO;
using ControlTrafico.Application.Services.APIServices;
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
        private readonly IApiService _apiService;
        private readonly IRutasRepository _rutaRepository;
        private readonly IFlujoRepository _flujoRpository;

        public RutaService(IRutasRepository rutaRepository, IFlujoRepository flujoRpository, IMapper mapper, IApiService apiService)
        {
            _rutaRepository = rutaRepository;
            this._flujoRpository = flujoRpository;
            _mapper = mapper;
            this._apiService = apiService;
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
                    var vehiculoDisponible = _apiService.GetVehiculoDisponibleAsync(rutaDisponibleDTO.IdZona, rutaDisponibleDTO.IdTipoVehiculo);
                    var fechaActual = DateTime.Now;

                    fechaActual = DateTime.SpecifyKind(fechaActual, DateTimeKind.Unspecified);

                    //
                    DateTimeOffset localtime = new DateTimeOffset(fechaActual, new TimeSpan(-5, 0, 0));

                    //TimeZoneInfo.ConvertTime(DateTime.Now, timeZone)
                    //Insertamos Flujo
                    var flujos = await _flujoRpository.FindAllAsync(mm => mm.id_ruta == rutas.Id);

                    foreach (var flujobd in flujos)
                    {
                        flujobd.Estado = 0;
                        await _flujoRpository.UpdateAsync(flujobd,flujobd.Id);
                    }
                    await _flujoRpository.AddAsync(new Data.Domain.Entities.Flujo {fecha_hora_envio = localtime.DateTime, id_ruta = rutas.Id, IdVehiculo = vehiculoDisponible.Result.Id, Estado = 1 });

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
