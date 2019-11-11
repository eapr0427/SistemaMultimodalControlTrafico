using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ControlTrafico.Application.DTO;
using ControlTrafico.Presentation.Admin.Data;
using ControlTrafico.ExternalServices.Services;
using ControlTrafico.Application.Services.Contracts;

namespace ControlTrafico.Presentation.Admin.Controllers
{
    public class EstacionesController : Controller
    {
        private readonly IApiService _apiService;
        private readonly IEstacionService _estacionService;

        public EstacionesController(IApiService apiService, IEstacionService estacionService)
        {
            this._apiService = apiService;
            this._estacionService = estacionService;
        }

        // GET: Estaciones
        public async Task<IActionResult> Index()
        {
            var response = await _apiService.GetEstacionesAsync();
            if (response == null)
            {
                return NotFound();
            }

            return View(response.Result.ListStation);
        }

        // GET: Estaciones/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            return null;
            //if (id == null)
            //{
            //    return NotFound();
            //}

            //var estacionesRootResponseDto = await _context.EstacionesRootResponseDto
            //    .FirstOrDefaultAsync(m => m.Id == id);
            //if (estacionesRootResponseDto == null)
            //{
            //    return NotFound();
            //}

            //return View(estacionesRootResponseDto);
        }

        public async Task<IActionResult> CargarEstaciones()
        {
            var response = await _apiService.GetEstacionesAsync();
            if (response == null)
            {
                return NotFound();
            }

            await _estacionService.CargarEstaciones(response.Result);

            //return View(.listStation);
            return RedirectToAction(nameof(Index));
        }

            //// GET: Estaciones/Create
            //public IActionResult Create()
            //{
            //    return View();
            //}

            //// POST: Estaciones/Create
            //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
            //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
            //[HttpPost]
            //[ValidateAntiForgeryToken]
            //public async Task<IActionResult> Create([Bind("Id")] EstacionesRootResponseDto estacionesRootResponseDto)
            //{
            //    if (ModelState.IsValid)
            //    {
            //        _context.Add(estacionesRootResponseDto);
            //        await _context.SaveChangesAsync();
            //        return RedirectToAction(nameof(Index));
            //    }
            //    return View(estacionesRootResponseDto);
            //}

            //// GET: Estaciones/Edit/5
            //public async Task<IActionResult> Edit(int? id)
            //{
            //    if (id == null)
            //    {
            //        return NotFound();
            //    }

            //    var estacionesRootResponseDto = await _context.EstacionesRootResponseDto.FindAsync(id);
            //    if (estacionesRootResponseDto == null)
            //    {
            //        return NotFound();
            //    }
            //    return View(estacionesRootResponseDto);
            //}

            //// POST: Estaciones/Edit/5
            //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
            //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
            //[HttpPost]
            //[ValidateAntiForgeryToken]
            //public async Task<IActionResult> Edit(int id, [Bind("Id")] EstacionesRootResponseDto estacionesRootResponseDto)
            //{
            //    if (id != estacionesRootResponseDto.Id)
            //    {
            //        return NotFound();
            //    }

            //    if (ModelState.IsValid)
            //    {
            //        try
            //        {
            //            _context.Update(estacionesRootResponseDto);
            //            await _context.SaveChangesAsync();
            //        }
            //        catch (DbUpdateConcurrencyException)
            //        {
            //            if (!EstacionesRootResponseDtoExists(estacionesRootResponseDto.Id))
            //            {
            //                return NotFound();
            //            }
            //            else
            //            {
            //                throw;
            //            }
            //        }
            //        return RedirectToAction(nameof(Index));
            //    }
            //    return View(estacionesRootResponseDto);
            //}

            //// GET: Estaciones/Delete/5
            //public async Task<IActionResult> Delete(int? id)
            //{
            //    if (id == null)
            //    {
            //        return NotFound();
            //    }

            //    var estacionesRootResponseDto = await _context.EstacionesRootResponseDto
            //        .FirstOrDefaultAsync(m => m.Id == id);
            //    if (estacionesRootResponseDto == null)
            //    {
            //        return NotFound();
            //    }

            //    return View(estacionesRootResponseDto);
            //}

            //// POST: Estaciones/Delete/5
            //[HttpPost, ActionName("Delete")]
            //[ValidateAntiForgeryToken]
            //public async Task<IActionResult> DeleteConfirmed(int id)
            //{
            //    var estacionesRootResponseDto = await _context.EstacionesRootResponseDto.FindAsync(id);
            //    _context.EstacionesRootResponseDto.Remove(estacionesRootResponseDto);
            //    await _context.SaveChangesAsync();
            //    return RedirectToAction(nameof(Index));
            //}

            //private bool EstacionesRootResponseDtoExists(int id)
            //{
            //    return _context.EstacionesRootResponseDto.Any(e => e.Id == id);
            //}
        }
}
