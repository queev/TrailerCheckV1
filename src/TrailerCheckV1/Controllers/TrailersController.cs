using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TrailerCheckV1.Data;
using TrailerCheckV1.Models;

namespace TrailerCheckV1.Controllers
{
    public class TrailersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TrailersController(ApplicationDbContext context)
        {
            _context = context;    
        }

        // GET: Trailers
        public async Task<IActionResult> Index(string searchString)
        {
            var trailers = from t in _context.Trailer
                           select t;

            if (!String.IsNullOrWhiteSpace(searchString))
            {
                trailers = trailers.Where(s => s.SerialNumber.Contains(searchString));
            }
            return View(await trailers.ToListAsync());
        }

        // POST: Trailers
        [HttpPost]
        public string Index(string searchString, bool notUsed)
        {
            return "From [HttpPost]Index: search for " + searchString;
        }

        // GET: Trailers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trailer = await _context.Trailer.SingleOrDefaultAsync(m => m.ID == id);
            if (trailer == null)
            {
                return NotFound();
            }

            return View(trailer);
        }

        // GET: Trailers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Trailers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Model,ProductGroup,SerialNumber,Stolen,YearOfManufacture")] Trailer trailer)
        {
            if (ModelState.IsValid)
            {
                _context.Add(trailer);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(trailer);
        }

        // GET: Trailers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trailer = await _context.Trailer.SingleOrDefaultAsync(m => m.ID == id);
            if (trailer == null)
            {
                return NotFound();
            }
            return View(trailer);
        }

        // POST: Trailers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Model,ProductGroup,SerialNumber,Stolen,YearOfManufacture")] Trailer trailer)
        {
            if (id != trailer.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(trailer);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TrailerExists(trailer.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index");
            }
            return View(trailer);
        }

        // GET: Trailers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trailer = await _context.Trailer.SingleOrDefaultAsync(m => m.ID == id);
            if (trailer == null)
            {
                return NotFound();
            }

            return View(trailer);
        }

        // POST: Trailers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var trailer = await _context.Trailer.SingleOrDefaultAsync(m => m.ID == id);
            _context.Trailer.Remove(trailer);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool TrailerExists(int id)
        {
            return _context.Trailer.Any(e => e.ID == id);
        }
    }
}
