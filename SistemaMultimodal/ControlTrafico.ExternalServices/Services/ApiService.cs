using ControlTrafico.Application.DTO;
using ControlTrafico.ExternalServices.Core;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ControlTrafico.ExternalServices.Services
{
    public class ApiService : IApiService
    {

        public async Task<ResponseDto<EstacionesRootResponseDto>> GetEstaciones()
        {
            var instancia = new Servicio<EstacionesRootResponseDto>();
            ServicioRest payload = new ServicioRest
            {
                UrlBase = "http://138.91.126.154/",
                ServicePrefix  = "infraestructura/api",
                Controller = "/station/"
            };

            var respuesta = await instancia.MapearServicio(payload);

            return new ResponseDto<EstacionesRootResponseDto>
            {
                IsSuccess = true,
                Result = respuesta
            };

        }
    }
}
