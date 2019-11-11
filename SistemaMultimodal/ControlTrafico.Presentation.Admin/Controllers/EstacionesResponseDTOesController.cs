using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ControlTrafico.Application.DTO;
using ControlTrafico.Presentation.Admin.Data;

namespace ControlTrafico.Presentation.Admin.Controllers
{
    public class EstacionesResponseDTOesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EstacionesResponseDTOesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: EstacionesResponseDTOes
        public async Task<IActionResult> Index()
        {
            return View(await _context.EstacionesResponseDTO.ToListAsync());
        }

        // GET: EstacionesResponseDTOes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var estacionesResponseDTO = await _context.EstacionesResponseDTO
                .FirstOrDefaultAsync(m => m.Id == id);
            if (estacionesResponseDTO == null)
            {
                return NotFound();
            }

            return View(estacionesResponseDTO);
        }

        // GET: EstacionesResponseDTOes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: EstacionesResponseDTOes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,IdStation,NameStation")] EstacionesResponseDTO estacionesResponseDTO)
        {
            if (ModelState.IsValid)
            {
                _context.Add(estacionesResponseDTO);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(estacionesResponseDTO);
        }

        // GET: EstacionesResponseDTOes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var estacionesResponseDTO = await _context.EstacionesResponseDTO.FindAsync(id);
            if (estacionesResponseDTO == null)
            {
                return NotFound();
            }
            return View(estacionesResponseDTO);
        }

        // POST: EstacionesResponseDTOes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,IdStation,NameStation")] EstacionesResponseDTO estacionesResponseDTO)
        {
            if (id != estacionesResponseDTO.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(estacionesResponseDTO);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EstacionesResponseDTOExists(estacionesResponseDTO.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(estacionesResponseDTO);
        }

        // GET: EstacionesResponseDTOes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var estacionesResponseDTO = await _context.EstacionesResponseDTO
                .FirstOrDefaultAsync(m => m.Id == id);
            if (estacionesResponseDTO == null)
            {
                return NotFound();
            }

            return View(estacionesResponseDTO);
        }

        // POST: EstacionesResponseDTOes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var estacionesResponseDTO = await _context.EstacionesResponseDTO.FindAsync(id);
            _context.EstacionesResponseDTO.Remove(estacionesResponseDTO);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EstacionesResponseDTOExists(int id)
        {
            return _context.EstacionesResponseDTO.Any(e => e.Id == id);
        }
    }
}
