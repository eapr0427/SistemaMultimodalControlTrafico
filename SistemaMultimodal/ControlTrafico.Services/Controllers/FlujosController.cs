using ControlTrafico.Application.DTO;
using ControlTrafico.Application.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace ControlTrafico.Services.Controllers
{
    public class FlujosController : ApiController
    {
        private readonly IFlujoService _flujosService;

        public FlujosController(IFlujoService flujosService)
        {
            _flujosService = flujosService;
        }

        [HttpGet]
        public async Task<IEnumerable<FlujoDto>> GetFlujos()
        {
            return await _flujosService.GetFlujos();
        }
    }
}
