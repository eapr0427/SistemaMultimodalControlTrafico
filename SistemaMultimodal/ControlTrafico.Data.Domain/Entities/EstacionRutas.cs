using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlTrafico.Data.Domain.Entities
{
    [Table("ESTACION_RUTAS")]
    public class EstacionRutas : Entity<long>
    {
        public long id_est_ruta { get; set; }
        public long id_estacion { get; set; }
        public long id_ruta { get; set; }
        public long orden { get; set; }
        //public virtual ICollection<SOLICITUDES> SOLICITUDES { get; set; }
        public virtual Estacion Estaciones { get; set; }
        public virtual Ruta Ruta { get; set; }
    }
}
