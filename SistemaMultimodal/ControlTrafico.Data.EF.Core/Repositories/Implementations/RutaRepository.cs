using ControlTrafico.Data.Domain.Entities;
using ControlTrafico.Data.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ControlTrafico.Data.EF.Core.Repositories.Implementations
{
    public class RutaRepository : Repository<RutasDisponibles, long>, IRutasRepository
    {
        private readonly UnitOfWork _unitOfWork;

        public RutaRepository(UnitOfWork unitOfWork) : base(unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<RutasDisponibles>> GetRutasDisponibles()
        {
            try
            {
                var rutasDisponibles = await _unitOfWork.RutasDisponibles
                 .FromSqlRaw<RutasDisponibles>("EXECUTE dbo.SP_CONSULTARRUTASDISPONIBLES").ToListAsync();

                return rutasDisponibles;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return null;
        }
    }
}
