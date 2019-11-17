using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlTrafico.Data.Domain.Entities
{
    public class RutasDisponibles : Entity<long>
    {
        [Column("nombre_ruta")]
        public string NombreRuta { get; set; }
        [Column("id_tipo_vehiculo")]
        public int IdTipoVehiculo { get; set; }
        [Column("tipo_vehiculo")]
        public string TipoVehiculo { get; set; }
        [Column("hora_salida")]
        public string HoraSalida { get; set; }
        [Column("proxima_salida")]
        public string ProximaSalida { get; set; }
        [Column("capacidad")]
        public int Capacidad { get; set; }
        [Column("id_zona")]
        public int IdZona { get; set; }
        [Column("nombre_zona")]
        public string NombreZona { get; set; }
    }
}
