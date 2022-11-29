using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AtividadeMVC1.Data;
using AtividadeMVC1.EF;

namespace AtividadeMVC1.Controllers
{
    public class CancelamentoesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CancelamentoesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Cancelamentoes
        public async Task<IActionResult> Index()
        {
            return View(await _context.Cancelamento.ToListAsync());
        }

        // GET: Cancelamentoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cancelamento = await _context.Cancelamento
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cancelamento == null)
            {
                return NotFound();
            }

            return View(cancelamento);
        }

        // GET: Cancelamentoes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Cancelamentoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,CodigoCancelamento")] Cancelamento cancelamento)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cancelamento);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cancelamento);
        }

        // GET: Cancelamentoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cancelamento = await _context.Cancelamento.FindAsync(id);
            if (cancelamento == null)
            {
                return NotFound();
            }
            return View(cancelamento);
        }

        // POST: Cancelamentoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,CodigoCancelamento")] Cancelamento cancelamento)
        {
            if (id != cancelamento.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cancelamento);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CancelamentoExists(cancelamento.Id))
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
            return View(cancelamento);
        }

        // GET: Cancelamentoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cancelamento = await _context.Cancelamento
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cancelamento == null)
            {
                return NotFound();
            }

            return View(cancelamento);
        }

        // POST: Cancelamentoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cancelamento = await _context.Cancelamento.FindAsync(id);
            _context.Cancelamento.Remove(cancelamento);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CancelamentoExists(int id)
        {
            return _context.Cancelamento.Any(e => e.Id == id);
        }
    }
}
