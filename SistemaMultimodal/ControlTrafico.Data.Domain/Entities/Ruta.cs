using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlTrafico.Data.Domain.Entities
{
    [Table("RUTAS")]
    public class Ruta : Entity<long>
    {
        //public long id_ruta { get; set; }
        public string nombre_ruta { get; set; }
        public System.TimeSpan hora_inicio { get; set; }
        public System.TimeSpan hora_fin { get; set; }
        public string estado { get; set; }


        public virtual ICollection<EstacionRutas> EstacionRutas { get; set; }
        //public virtual ICollection<PARAMETROS_RUTAS> PARAMETROS_RUTAS { get; set; }

    }
}
