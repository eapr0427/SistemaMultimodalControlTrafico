using ControlTrafico.Data.Domain.Entities;
using ControlTrafico.Data.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace ControlTrafico.Data.EF.Core.Repositories.Implementations
{
    public class EstacionRepository : Repository<Estacion, long>, IEstacionRepository
    {
        public EstacionRepository(UnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}
