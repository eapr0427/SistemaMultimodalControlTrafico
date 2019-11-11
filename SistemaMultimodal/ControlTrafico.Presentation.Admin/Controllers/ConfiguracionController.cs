using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ControlTrafico.ExternalServices.Services;
using Microsoft.AspNetCore.Mvc;

namespace ControlTrafico.Presentation.Admin.Controllers
{
    public class ConfiguracionController : Controller
    {
        private readonly IApiService _apiService;

        public ConfiguracionController(IApiService apiService)
        {
            this._apiService = apiService;
        }
        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> LoadEstaciones()
        {
           await _apiService.GetEstacionesAsync();
            return RedirectToPage("./Index");
        }

    }
}