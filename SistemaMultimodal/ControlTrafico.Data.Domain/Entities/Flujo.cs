using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlTrafico.Data.Domain.Entities
{
    [Table("FLUJO")]
    public class Flujo : Entity<long>
    {
        public long id_ruta { get; set; }
        public System.DateTime fecha_hora_envio { get; set; }
    }
}
