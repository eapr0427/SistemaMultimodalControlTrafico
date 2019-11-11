using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlTrafico.Data.Domain.Entities
{
    [Table("ESTACIONES")]
    public class Estacion : Entity<long>
    { 
        public string nombre { get; set; }
        public string estado { get; set; }
        public long id_estacion_infra { get; set; }
        public virtual ICollection<EstacionRutas> EstacionRutas { get; set; }
    }
}
