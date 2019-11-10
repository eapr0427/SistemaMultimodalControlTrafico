using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlTrafico.Application.DTO
{
    public class EstacionesResponseDTO
    {
        public int IdStation { get; set; }
        public string NameStation { get; set; }
        [JsonProperty("CodTypeStation")]
        public TipoEstacionResponseDTO TypeStation { get; set; }
        [JsonProperty("CodZone")]
        public ZonaEstacionResponseDTO CodZone { get; set; }
    }
}
