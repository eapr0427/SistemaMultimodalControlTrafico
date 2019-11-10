using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ControlTrafico.Application.DTO;
using ControlTrafico.Data.Domain.Repositories;

namespace ControlTrafico.Application.Services
{
    public class FlujoService : IFlujoService
    {
        private readonly IFlujoRepository _flujoRepository;

        public FlujoService(IFlujoRepository flujoRepository)
        {
            _flujoRepository = flujoRepository;
        }
        public async Task<IEnumerable<FlujoDto>> GetFlujos()
        {
            var videos = await _flujoRepository.GetAllAsync();
            //TODO AUTOMAPPER
            return null;
            //return videos.Select
        }
    }
}
