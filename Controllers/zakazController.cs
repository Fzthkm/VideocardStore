using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Магазин.Models;

namespace Магазин.Views
{
    public class zakazController : Controller
    {
        private readonly context _context;

        public zakazController(context context)
        {
            _context = context;
        }

        // GET: zakaz
        public async Task<IActionResult> Index()
        {
            var context = _context.zakazi.Include(z => z.tovar);
            return View(await context.ToListAsync());
        }

        // GET: zakaz/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var zakaz = await _context.zakazi
                .Include(z => z.tovar)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (zakaz == null)
            {
                return NotFound();
            }

            return View(zakaz);
        }

        // GET: zakaz/Create
        public IActionResult Create()
        {
            ViewData["tovarId"] = new SelectList(_context.tovari, "Id", "Id");
            return View();
        }

        // POST: zakaz/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("kolichestvo,sposobDostavki,karta,adres,poluchatel")] zakaz zakaz, int? id)
        {
            if (ModelState.IsValid)
            {
                if (id == null)
                {
                    return NotFound();
                }
                tovar tovar = _context.tovari.FirstOrDefault(x=>x.Id == id);
                if(zakaz.kolichestvo > tovar.kolichestvoNaSklade)
                {
                    return RedirectToAction("ErrorCount");
                }
                zakaz.status = mode.oplachen;
                zakaz.tovarId = (int)id;
                tovar.kolichestvoNaSklade -= zakaz.kolichestvo;
                _context.tovari.Update(tovar);
                _context.Add(zakaz);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["tovarId"] = new SelectList(_context.tovari, "Id", "Id", zakaz.tovarId);
            return View(zakaz);
        }
        public async Task<IActionResult> Oplata(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var zakaz = await _context.zakazi.FindAsync(id);
            if (zakaz == null)
            {
                return NotFound();
            }
            ViewData["tovarId"] = new SelectList(_context.tovari, "Id", "Id", zakaz.tovarId);
            zakaz.status = mode.oplachen;
            _context.zakazi.Update(zakaz);
            _context.SaveChanges();
            return View(zakaz);
        }
        // GET: zakaz/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var zakaz = await _context.zakazi.FindAsync(id);
            if (zakaz == null)
            {
                return NotFound();
            }
            ViewData["tovarId"] = new SelectList(_context.tovari, "Id", "Id", zakaz.tovarId);
            return View(zakaz);
        }

        // POST: zakaz/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.



        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,kolichestvo,status,sposobDostavki,tovarId")] zakaz zakaz)
        {
            if (id != zakaz.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(zakaz);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!zakazExists(zakaz.Id))
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
            ViewData["tovarId"] = new SelectList(_context.tovari, "Id", "Id", zakaz.tovarId);
            return View(zakaz);
        }

        // GET: zakaz/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var zakaz = await _context.zakazi
                .Include(z => z.tovar)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (zakaz == null)
            {
                return NotFound();
            }

            return View(zakaz);
        }

        // POST: zakaz/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var zakaz = await _context.zakazi.FindAsync(id);
            _context.zakazi.Remove(zakaz);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool zakazExists(int id)
        {
            return _context.zakazi.Any(e => e.Id == id);
        }
    }
}
