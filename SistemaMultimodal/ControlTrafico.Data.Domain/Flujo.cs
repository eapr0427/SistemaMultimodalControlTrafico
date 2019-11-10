using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlTrafico.Data.Domain
{
    public class Flujo : Entity<Guid>
    {
        public long IdFlujo { get; set; }
        public long IdRuta { get; set; }
        public DateTime FechaHoraEnvio { get; set; }
    }
}
