using ControlTrafico.Data.Domain;
using ControlTrafico.Data.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace ControlTrafico.Data.EF.Core.Repositories.Implementations
{
    public class FlujoRepository : Repository<Flujo, Guid>, IFlujoRepository
    {
        public FlujoRepository(UnitOfWork unitOfWork) : base(unitOfWork)
        {

        }
    }
}
