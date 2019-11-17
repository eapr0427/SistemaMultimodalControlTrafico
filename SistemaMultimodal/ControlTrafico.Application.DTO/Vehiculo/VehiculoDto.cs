using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlTrafico.Application.DTO.Vehiculo
{
    public class VehiculoDto
    {
        [JsonProperty("IdVehicle")]
        public string Id { get; set; }
        [JsonProperty("type")]
        public TipoVehiculoDTO Tipo { get; set; }
        [JsonProperty("capable")]
        public int Capacidad { get; set; }
        //public Zone zone { get; set; }
        public bool Status { get; set; }
        public int Mileage { get; set; }
    }
}
