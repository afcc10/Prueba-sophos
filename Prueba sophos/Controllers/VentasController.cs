using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Prueba_sophos.Models;

namespace Prueba_sophos.Controllers
{
    public class VentasController : Controller
    {
        private readonly VentasContext _context;

        public VentasController(VentasContext context)
        {
            _context = context;
        }

        // GET: Ventas
        public async Task<IActionResult> Index()
        {
            var ventasContext = _context.Venta.Include(v => v.IdClienteNavigation).Include(v => v.IdProductoNavigation);
            return View(await ventasContext.ToListAsync());
        }

        // GET: Ventas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ventas = await _context.Venta
                .Include(v => v.IdClienteNavigation)
                .Include(v => v.IdProductoNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ventas == null)
            {
                return NotFound();
            }

            return View(ventas);
        }

        // GET: Ventas/Create
        public IActionResult Create()
        {
            ViewData["IdCliente"] = new SelectList(_context.Usuarios, "Id", "Nombre");
            ViewData["IdProducto"] = new SelectList(_context.Productos, "Id", "Descripcion");
            return View();
        }

        // POST: Ventas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,IdCliente,IdProducto,Cantidad,ValorPagar")] Ventas ventas)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ventas);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdCliente"] = new SelectList(_context.Usuarios, "Id", "Id", ventas.IdCliente);
            ViewData["IdProducto"] = new SelectList(_context.Productos, "Id", "Id", ventas.IdProducto);
            return View(ventas);
        }

        // GET: Ventas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ventas = await _context.Venta.FindAsync(id);
            if (ventas == null)
            {
                return NotFound();
            }
            ViewData["IdCliente"] = new SelectList(_context.Usuarios, "Id", "Id", ventas.IdCliente);
            ViewData["IdProducto"] = new SelectList(_context.Productos, "Id", "Id", ventas.IdProducto);
            return View(ventas);
        }

        // POST: Ventas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,IdCliente,IdProducto,Cantidad,ValorPagar")] Ventas ventas)
        {
            if (id != ventas.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ventas);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VentasExists(ventas.Id))
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
            ViewData["IdCliente"] = new SelectList(_context.Usuarios, "Id", "Id", ventas.IdCliente);
            ViewData["IdProducto"] = new SelectList(_context.Productos, "Id", "Id", ventas.IdProducto);
            return View(ventas);
        }

        // GET: Ventas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ventas = await _context.Venta
                .Include(v => v.IdClienteNavigation)
                .Include(v => v.IdProductoNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ventas == null)
            {
                return NotFound();
            }

            return View(ventas);
        }

        // POST: Ventas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var ventas = await _context.Venta.FindAsync(id);
            _context.Venta.Remove(ventas);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VentasExists(int id)
        {
            return _context.Venta.Any(e => e.Id == id);
        }
    }
}
