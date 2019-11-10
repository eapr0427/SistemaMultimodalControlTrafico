using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ControlTrafico.Data;

namespace ControlTrafico.Data.Domain.Repositories
{
    public interface IFlujoRepository : IRepository<Flujo, Guid>
    {
    }
}
