using System;
using System.Collections.Generic;
using System.Text;

namespace ControlTrafico.Data
{
    public abstract class Entity
    {
        //public virtual DateTime FechaCrecion { get; set; }
        //public virtual DateTime FechaModificacion { get; set; }

    }

    public abstract class Entity<TEntityId> : Entity
    {
        public virtual TEntityId Id { get; set; }

        public virtual void UpdateFechaModificacion()
        {
            //if (this.FechaCrecion != default)
            //{
            //    this.FechaModificacion = DateTime.UtcNow;
            //}
        }
    }
}
