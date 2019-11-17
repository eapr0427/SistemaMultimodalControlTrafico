using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ControlTrafico.Application.DTO;
using ControlTrafico.Application.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ControlTrafico.Services.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FlujosController : ControllerBase
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

        //[HttpGet]
        //public async Task<IEnumerable<FlujoDto>> GetRutasDisponibles()
        //{
        //    return await _flujosService.GetRutasDisponibles();
        //}

    }
}