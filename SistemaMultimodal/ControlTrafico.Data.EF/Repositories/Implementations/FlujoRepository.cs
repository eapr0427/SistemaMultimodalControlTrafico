using ControlTrafico.Data.Domain;
using ControlTrafico.Data.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlTrafico.Data.EF.Repositories.Implementations
{
    public class FlujoRepository: Repository<Flujo, Guid>, IFlujoRepository
    {
        public FlujoRepository(UnitOfWork unitOfWork) : base(unitOfWork)
        {

        }
    }
}
