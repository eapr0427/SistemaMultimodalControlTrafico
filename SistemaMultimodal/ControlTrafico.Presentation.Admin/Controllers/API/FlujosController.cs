using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ControlTrafico.Application.DTO;
using ControlTrafico.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace ControlTrafico.Presentation.Admin.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class FlujosController : Controller
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