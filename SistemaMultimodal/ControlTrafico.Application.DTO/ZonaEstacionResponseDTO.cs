using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlTrafico.Application.DTO
{
    public class ZonaEstacionResponseDTO
    {
        public int Id { get; set; }
        public int IdZone { get; set; }
        public string NameZone { get; set; }
        public string DescriptionZone { get; set; }
        public string ColorZone { get; set; }
    }
}
