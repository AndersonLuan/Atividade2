using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Atividade2.Data;
using Atividade2.Models;

namespace Atividade2.Controllers
{
    public class PecasRoupasController : Controller
    {
        private readonly Atividade2Context _context;

        public PecasRoupasController(Atividade2Context context)
        {
            _context = context;
        }

        // GET: PecasRoupas
        public async Task<IActionResult> Index()
        {
            return View(await _context.PecasRoupa.ToListAsync());
        }

        // GET: PecasRoupas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pecasRoupa = await _context.PecasRoupa
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pecasRoupa == null)
            {
                return NotFound();
            }

            return View(pecasRoupa);
        }

        // GET: PecasRoupas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PecasRoupas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,TipoRoupa,Quantidade")] PecasRoupa pecasRoupa)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pecasRoupa);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(pecasRoupa);
        }

        // GET: PecasRoupas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pecasRoupa = await _context.PecasRoupa.FindAsync(id);
            if (pecasRoupa == null)
            {
                return NotFound();
            }
            return View(pecasRoupa);
        }

        // POST: PecasRoupas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,TipoRoupa,Quantidade")] PecasRoupa pecasRoupa)
        {
            if (id != pecasRoupa.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pecasRoupa);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PecasRoupaExists(pecasRoupa.Id))
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
            return View(pecasRoupa);
        }

        // GET: PecasRoupas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pecasRoupa = await _context.PecasRoupa
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pecasRoupa == null)
            {
                return NotFound();
            }

            return View(pecasRoupa);
        }

        // POST: PecasRoupas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pecasRoupa = await _context.PecasRoupa.FindAsync(id);
            _context.PecasRoupa.Remove(pecasRoupa);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PecasRoupaExists(int id)
        {
            return _context.PecasRoupa.Any(e => e.Id == id);
        }
    }
}
