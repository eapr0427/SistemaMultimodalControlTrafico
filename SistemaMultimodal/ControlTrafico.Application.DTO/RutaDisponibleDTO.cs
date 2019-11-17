using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlTrafico.Application.DTO
{
    public class RutaDisponibleDTO
    {
        public string NombreRuta { get; set; }
        public int IdTipoVehiculo { get; set; }
        public string TipoVehiculo { get; set; }
        public string HoraSalida { get; set; }
        public string ProximaSalida { get; set; }
        public int Capacidad { get; set; }
        public int IdZona { get; set; }
        public string NombreZona { get; set; }
    }
}
