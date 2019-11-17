using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ControlTrafico.Application.DTO;
using ControlTrafico.Application.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ControlTrafico.Presentation.Admin.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class RutasController : ControllerBase
    {
        private readonly IRutaService _rutasService;

        public RutasController(IRutaService rutasService)
        {
            _rutasService = rutasService;
        }

        [HttpGet]
        public async Task<IEnumerable<RutaDisponibleDTO>> GetRutasDisponibles()
        {
            return await _rutasService.GetRutasDisponibles();
        }

    }
}