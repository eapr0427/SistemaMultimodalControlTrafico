using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlTrafico.Data.Domain
{
    public class Flujo : Entity<Guid>
    {
        [Column("id_flujo")]
        public long IdFlujo { get; set; }
        [Column("id_ruta")]
        public long IdRuta { get; set; }
        [Column("fecha_hora_envio")]
        public DateTime FechaHoraEnvio { get; set; }
    }
}
