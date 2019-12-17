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
    public class ConfeccoesController : Controller
    {
        private readonly Atividade2Context _context;

        public ConfeccoesController(Atividade2Context context)
        {
            _context = context;
        }

        // GET: Confeccoes
        public async Task<IActionResult> Index()
        {
            return View(await _context.Confeccoes.ToListAsync());
        }

        // GET: Confeccoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var confeccoes = await _context.Confeccoes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (confeccoes == null)
            {
                return NotFound();
            }

            return View(confeccoes);
        }

        // GET: Confeccoes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Confeccoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Registro")] Confeccoes confeccoes)
        {
            if (ModelState.IsValid)
            {
                _context.Add(confeccoes);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(confeccoes);
        }

        // GET: Confeccoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var confeccoes = await _context.Confeccoes.FindAsync(id);
            if (confeccoes == null)
            {
                return NotFound();
            }
            return View(confeccoes);
        }

        // POST: Confeccoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Registro")] Confeccoes confeccoes)
        {
            if (id != confeccoes.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(confeccoes);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ConfeccoesExists(confeccoes.Id))
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
            return View(confeccoes);
        }

        // GET: Confeccoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var confeccoes = await _context.Confeccoes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (confeccoes == null)
            {
                return NotFound();
            }

            return View(confeccoes);
        }

        // POST: Confeccoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var confeccoes = await _context.Confeccoes.FindAsync(id);
            _context.Confeccoes.Remove(confeccoes);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ConfeccoesExists(int id)
        {
            return _context.Confeccoes.Any(e => e.Id == id);
        }
    }
}
