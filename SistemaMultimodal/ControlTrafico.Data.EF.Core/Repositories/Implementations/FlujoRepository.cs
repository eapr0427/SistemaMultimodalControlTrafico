using ControlTrafico.Data.Domain;
using ControlTrafico.Data.Domain.Entities;
using ControlTrafico.Data.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ControlTrafico.Data.EF.Core.Repositories.Implementations
{
    public class FlujoRepository : Repository<Flujo, long>, IFlujoRepository
    {
        private readonly UnitOfWork _unitOfWork;


        public FlujoRepository(UnitOfWork unitOfWork) : base(unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<Flujo>> GetFlujosAsync()
        {
            try
            {
                var rutas = await _unitOfWork.Flujo.Include(mm => mm.Rutas).ToListAsync();
                return rutas;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}