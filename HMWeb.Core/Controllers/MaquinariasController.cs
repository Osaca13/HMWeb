using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HMWeb.Biblioteca.Modelos;

namespace HMWeb.Core.Controllers
{
    
    public class MaquinariasController : Controller
    {
        private readonly HMContext _context;

        public MaquinariasController(HMContext context)
        {
            _context = context;
        }

        // GET: Maquinarias
        public async Task<IActionResult> Index()
        {
            ViewData["IdCentro"] = new SelectList(_context.Centros, "IdCentro", "Nombre");
            ViewData["IdEmpresa"] = new SelectList(_context.Empresas, "IdEmpresa", "IdEmpresa");
            ViewData["IdServicio"] = new SelectList(_context.Servicios, "IdServicio", "IdServicio");
            var hMContext = _context.Maquinarias.Include(m => m.IdCentroNavigation).Include(m => m.IdEmpresaNavigation).Include(m => m.IdServicioNavigation);
            return View(await hMContext.ToListAsync());
        }

        // GET: Maquinarias/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var maquinarias = await _context.Maquinarias
                .Include(m => m.IdCentroNavigation)
                .Include(m => m.IdEmpresaNavigation)
                .Include(m => m.IdServicioNavigation)
                .FirstOrDefaultAsync(m => m.IdMaquinaria == id);
            if (maquinarias == null)
            {
                return NotFound();
            }

            return View(maquinarias);
        }

        // GET: Maquinarias/Create
        public IActionResult Create()
        {
            ViewData["IdCentro"] = new SelectList(_context.Centros, "IdCentro", "Nombre");
            ViewData["IdEmpresa"] = new SelectList(_context.Empresas, "IdEmpresa", "IdEmpresa");
            ViewData["IdServicio"] = new SelectList(_context.Servicios, "IdServicio", "IdServicio");
            return View();
        }

        // POST: Maquinarias/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdMaquinaria,IdEmpresa,IdCentro,IdServicio,NumeroSerie,Matricula,FechaAlta,FechaBaja,Activa,UltimaLecturaKms,UltimaLecturaHoras,IndicaKH")] Maquinarias maquinarias)
        {
            if (ModelState.IsValid)
            {
                _context.Add(maquinarias);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdCentro"] = new SelectList(_context.Centros, "IdCentro", "Nombre", maquinarias.IdCentro);
            ViewData["IdEmpresa"] = new SelectList(_context.Empresas, "IdEmpresa", "IdEmpresa", maquinarias.IdEmpresa);
            ViewData["IdServicio"] = new SelectList(_context.Servicios, "IdServicio", "IdServicio", maquinarias.IdServicio);
            return View(maquinarias);
        }

        //public IActionResult _Edit()
        //{
        //    ViewData["IdCentro"] = new SelectList(_context.Centros, "IdCentro", "Nombre");
        //    ViewData["IdEmpresa"] = new SelectList(_context.Empresas, "IdEmpresa", "IdEmpresa");
        //    ViewData["IdServicio"] = new SelectList(_context.Servicios, "IdServicio", "IdServicio");
        //    return View();
        //}

        // GET: Maquinarias/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var maquinarias = await _context.Maquinarias.FindAsync(id);
            if (maquinarias == null)
            {
                return NotFound();
            }
            ViewData["IdCentro"] = new SelectList(_context.Centros, "IdCentro", "Nombre", maquinarias.IdCentro);
            ViewData["IdEmpresa"] = new SelectList(_context.Empresas, "IdEmpresa", "IdEmpresa", maquinarias.IdEmpresa);
            ViewData["IdServicio"] = new SelectList(_context.Servicios, "IdServicio", "IdServicio", maquinarias.IdServicio);
            return View(maquinarias);
        }

        // POST: Maquinarias/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdMaquinaria,IdEmpresa,IdCentro,IdServicio,NumeroSerie,Matricula,FechaAlta,FechaBaja,Activa,UltimaLecturaKms,UltimaLecturaHoras,IndicaKH")] Maquinarias maquinarias)
        {
            if (id != maquinarias.IdMaquinaria)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(maquinarias);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MaquinariasExists(maquinarias.IdMaquinaria))
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
            ViewData["IdCentro"] = new SelectList(_context.Centros, "IdCentro", "Nombre", maquinarias.IdCentro);
            ViewData["IdEmpresa"] = new SelectList(_context.Empresas, "IdEmpresa", "IdEmpresa", maquinarias.IdEmpresa);
            ViewData["IdServicio"] = new SelectList(_context.Servicios, "IdServicio", "IdServicio", maquinarias.IdServicio);
            return View(maquinarias);
        }

        // GET: Maquinarias/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var maquinarias = await _context.Maquinarias
                .Include(m => m.IdCentroNavigation)
                .Include(m => m.IdEmpresaNavigation)
                .Include(m => m.IdServicioNavigation)
                .FirstOrDefaultAsync(m => m.IdMaquinaria == id);
            if (maquinarias == null)
            {
                return NotFound();
            }

            return View(maquinarias);
        }

        // POST: Maquinarias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var maquinarias = await _context.Maquinarias.FindAsync(id);
            _context.Maquinarias.Remove(maquinarias);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MaquinariasExists(int id)
        {
            return _context.Maquinarias.Any(e => e.IdMaquinaria == id);
        }
    }
}
