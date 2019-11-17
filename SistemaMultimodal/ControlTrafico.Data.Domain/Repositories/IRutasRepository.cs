using ControlTrafico.Data.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlTrafico.Data.Domain.Repositories
{
    public interface IRutasRepository
    { 
        Task<List<RutasDisponibles>> GetRutasDisponibles();
    }
}
