using ControlTrafico.Application.DTO;
using ControlTrafico.Application.DTO.Vehiculo;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ControlTrafico.ExternalServices.Services
{
    public interface IApiService
    {
        Task<ResponseDto<EstacionesRootResponseDto>> GetEstacionesAsync();
        ResponseDto<VehiculoDto> GetVehiculoDisponiblesync();
    }
}
