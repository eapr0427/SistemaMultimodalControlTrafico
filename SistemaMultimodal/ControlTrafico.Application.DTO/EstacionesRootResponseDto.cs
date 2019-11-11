using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlTrafico.Application.DTO
{
    public class EstacionesRootResponseDto
    {

        [JsonProperty("listStation")]
        public List<EstacionesResponseDTO> ListStation { get; set; }
    }
}
