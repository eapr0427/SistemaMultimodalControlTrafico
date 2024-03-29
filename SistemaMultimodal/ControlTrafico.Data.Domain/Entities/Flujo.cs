﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlTrafico.Data.Domain.Entities
{
    [Table("FLUJO")]
    public class Flujo : Entity<long>
    {
        public long id_ruta { get; set; }
        public System.DateTime fecha_hora_envio { get; set; }
        [Column("estado")]
        public int Estado { get; set; }
        [Column("id_vehiculo")]
        public string IdVehiculo { get; set; }
        [ForeignKey("id_ruta")]
        public virtual Ruta Rutas { get; set; }
    }
}
