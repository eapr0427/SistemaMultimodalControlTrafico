using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using ControlTrafico.Application.DTO;
using ControlTrafico.Data.Domain.Repositories;

namespace ControlTrafico.Application.Services
{
    public class FlujoService : IFlujoService
    {
        private readonly IMapper _mapper;
        private readonly IFlujoRepository _flujoRepository;

        public FlujoService(IFlujoRepository flujoRepository, IMapper mapper)
        {
            _flujoRepository = flujoRepository;
            _mapper = mapper;
        }
        public async Task<IEnumerable<FlujoDto>> GetFlujos()
        {
            var flujos = await _flujoRepository.GetFlujosAsync();
            List<FlujoDto> flujoDtos = new List<FlujoDto>();
            foreach (var flujo in flujos)
            {
                var flujoDTO = _mapper.Map<FlujoDto>(flujo);
                flujoDtos.Add(flujoDTO);
            }
            return flujoDtos;
        }


    }
}
