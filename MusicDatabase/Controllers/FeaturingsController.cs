using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MusicDatabase.Data;
using MusicDatabase.Data.Tables;

namespace MusicDatabase.Controllers
{
    public class FeaturingsController : Controller
    {
        private readonly MusicDbContext _context;

        public FeaturingsController(MusicDbContext context)
        {
            _context = context;
        }

        // GET: Featurings
        public async Task<IActionResult> Index()
        {
            var musicDbContext = _context.Featurings.Include(f => f.Artist).Include(f => f.Song);
            return View(await musicDbContext.ToListAsync());
        }

        // GET: Featurings/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var featuring = await _context.Featurings
                .Include(f => f.Artist)
                .Include(f => f.Song)
                .SingleOrDefaultAsync(m => m.FeaturingId == id);
            if (featuring == null)
            {
                return NotFound();
            }

            return View(featuring);
        }

        // GET: Featurings/Create
        public IActionResult Create()
        {
            ViewData["ArtistId"] = new SelectList(_context.Artists, "ArtistId", "ArtistName");
            ViewData["SongId"] = new SelectList(_context.Songs, "SongId", "SongName");
            return View();
        }

        // POST: Featurings/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FeaturingId,SongId,ArtistId")] Featuring featuring)
        {
            if (ModelState.IsValid)
            {
                _context.Add(featuring);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ArtistId"] = new SelectList(_context.Artists, "ArtistId", "ArtistName");
            ViewData["SongId"] = new SelectList(_context.Songs, "SongId", "SongName");
            return View(featuring);
        }

        // GET: Featurings/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var featuring = await _context.Featurings.SingleOrDefaultAsync(m => m.FeaturingId == id);
            if (featuring == null)
            {
                return NotFound();
            }
            ViewData["ArtistId"] = new SelectList(_context.Artists, "ArtistId", "ArtistName");
            ViewData["SongId"] = new SelectList(_context.Songs, "SongId", "SongName");
            return View(featuring);
        }

        // POST: Featurings/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("FeaturingId,SongId,ArtistId")] Featuring featuring)
        {
            if (id != featuring.FeaturingId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(featuring);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FeaturingExists(featuring.FeaturingId))
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
            ViewData["ArtistId"] = new SelectList(_context.Artists, "ArtistId", "ArtistName");
            ViewData["SongId"] = new SelectList(_context.Songs, "SongId", "SongName");
            return View(featuring);
        }

        // GET: Featurings/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var featuring = await _context.Featurings
                .Include(f => f.Artist)
                .Include(f => f.Song)
                .SingleOrDefaultAsync(m => m.FeaturingId == id);
            if (featuring == null)
            {
                return NotFound();
            }

            return View(featuring);
        }

        // POST: Featurings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var featuring = await _context.Featurings.SingleOrDefaultAsync(m => m.FeaturingId == id);
            _context.Featurings.Remove(featuring);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FeaturingExists(int id)
        {
            return _context.Featurings.Any(e => e.FeaturingId == id);
        }
    }
}
