using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlTrafico.Application.DTO
{
    public class EstacionesResponseDTO
    {
        public int Id { get; set; }
        public int IdStation { get; set; }
        [Display(Name = "Nombre de la Estación")]
        public string NameStation { get; set; }
        [JsonProperty("CodTypeStation")]
        public TipoEstacionResponseDTO TypeStation { get; set; }
        [JsonProperty("CodZone")]
        public ZonaEstacionResponseDTO CodZone { get; set; }
    }
}
