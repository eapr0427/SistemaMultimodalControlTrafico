using ControlTrafico.Data.Domain.Entities;
using System;

namespace ControlTrafico.Application.DTO
{
    public class FlujoDto
    {
        public long Id { get; set; }
        public long IdRuta { get; set; }
        public DateTime FechaHoraEnvio { get; set; }

        public Ruta Rutas { get; set; }
    }
}
