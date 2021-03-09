using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Магазин.Models;

namespace Магазин.Controllers
{
    public class tovarsController : Controller
    {
        private readonly context _context;

        public tovarsController(context context)
        {
            _context = context;
        }

        // GET: tovars
        public async Task<IActionResult> Index()
        {
            return View(await _context.tovari.ToListAsync());
        }

        // GET: tovars/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tovar = await _context.tovari
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tovar == null)
            {
                return NotFound();
            }

            return View(tovar);
        }

        // GET: tovars/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: tovars/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,stoimost,name,Image,kolichestvoNaSklade,opisanie,firma,razmer,color")] tovar tovar)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tovar);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tovar);
        }

        // GET: tovars/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tovar = await _context.tovari.FindAsync(id);
            if (tovar == null)
            {
                return NotFound();
            }
            return View(tovar);
        }

        // POST: tovars/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,stoimost,name,Image,kolichestvoNaSklade,opisanie,firma,razmer,color")] tovar tovar)
        {
            if (id != tovar.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tovar);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!tovarExists(tovar.Id))
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
            return View(tovar);
        }

        // GET: tovars/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tovar = await _context.tovari
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tovar == null)
            {
                return NotFound();
            }

            return View(tovar);
        }

        // POST: tovars/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tovar = await _context.tovari.FindAsync(id);
            _context.tovari.Remove(tovar);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool tovarExists(int id)
        {
            return _context.tovari.Any(e => e.Id == id);
        }
    }
}
