using ControlTrafico.Application.DTO;
using ControlTrafico.Application.DTO.Vehiculo;
using ControlTrafico.Application.Services.Core;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ControlTrafico.Application.Services.APIServices
{
    public class ApiService : IApiService
    {
        private const string BaseUrl = "http://138.91.126.154/";

        public async Task<ResponseDto<EstacionesRootResponseDto>> GetEstacionesAsync()
        {
            var instancia = new Servicio<EstacionesRootResponseDto>();
            ServicioRest payload = new ServicioRest
            {
                UrlBase = BaseUrl,
                ServicePrefix = "infraestructura/api",
                Controller = "/station/"
            };

            var respuesta = await instancia.MapearServicioGet(payload);

            return new ResponseDto<EstacionesRootResponseDto>
            {
                IsSuccess = true,
                Result = respuesta
            };

        }

        public ResponseDto<VehiculoDto> GetVehiculoDisponiblesync(int idZona, int idTipoVehiculo)
        {
            //TODO Armar API DE CONSUMO
            return new ResponseDto<VehiculoDto>
            {
                IsSuccess = true,
                Result = JsonConvert.DeserializeObject<VehiculoDto>(MockRespuesta())
            };
        }
        public string MockRespuesta()
        {
            return "{\"IdVehicle\":\"ABC915\",\"type\":{\"IdTypVehicle\":2,\"NameTypeVehicle\":\"BIARTICULADO\"},\"capable\":228,\"zone\":{\"IdZone\":13,\"NameZone\":\"M\",\"DescriptionZone\":\"ZONA ORIENTE CENTRAL\",\"ColorZone\":\"LILA\"},\"Status\":true,\"Mileage\":96194}";
        }

    }
}
