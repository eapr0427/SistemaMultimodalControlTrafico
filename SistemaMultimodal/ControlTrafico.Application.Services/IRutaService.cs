using ControlTrafico.Application.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlTrafico.Application.Services
{
    public interface IRutaService
    {
        Task<IEnumerable<RutaDisponibleDTO>> GetRutasDisponibles();
    }
}
