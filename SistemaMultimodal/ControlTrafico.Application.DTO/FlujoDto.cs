using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlTrafico.Application.DTO
{
    public class FlujoDto
    {
        public long IdFlujo { get; set; }
        public long IdRuta { get; set; }
        public DateTime FechaHoraEnvio { get; set; }
    }
}
