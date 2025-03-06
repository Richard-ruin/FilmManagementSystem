using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FilmManagementSystem.Data;
using FilmManagementSystem.Models;
using System.Diagnostics;

namespace FilmManagementSystem.Controllers
{
    public class FilmsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<FilmsController> _logger;

        public FilmsController(ApplicationDbContext context, ILogger<FilmsController> logger)
        {
            _context = context;
            _logger = logger;
        }

        // GET: Films
        public async Task<IActionResult> Index()
        {
            try
            {
                var films = await _context.Films.ToListAsync();
                return View(films);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error in Index method: {ErrorMessage}", ex.Message);

                // Include inner exception details if available
                if (ex.InnerException != null)
                {
                    _logger.LogError(ex.InnerException, "Inner exception: {ErrorMessage}", ex.InnerException.Message);
                }

                throw; // Re-throw to see the detailed error page
            }
        }

        // GET: Films/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            try
            {
                var film = await _context.Films
                    .FirstOrDefaultAsync(m => m.Id == id);

                if (film == null)
                {
                    return NotFound();
                }

                return View(film);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving film details for ID: {Id}", id);
                return View("Error");
            }
        }

        // GET: Films/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Films/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Title,Director,ReleaseYear,Genre,Duration,Description")] Film film)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    film.DateAdded = DateTime.Now;
                    _context.Add(film);
                    await _context.SaveChangesAsync();
                    TempData["SuccessMessage"] = "Film berhasil ditambahkan!";
                    return RedirectToAction(nameof(Index));
                }
                return View(film);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error creating new film");
                ModelState.AddModelError("", "Terjadi kesalahan saat menyimpan data. Silakan coba lagi.");
                return View(film);
            }
        }

        // GET: Films/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            try
            {
                var film = await _context.Films.FindAsync(id);
                if (film == null)
                {
                    return NotFound();
                }
                return View(film);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving film for edit with ID: {Id}", id);
                return View("Error");
            }
        }

        // POST: Films/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Director,ReleaseYear,Genre,Duration,Description,DateAdded")] Film film)
        {
            if (id != film.Id)
            {
                return NotFound();
            }

            try
            {
                if (ModelState.IsValid)
                {
                    try
                    {
                        _context.Update(film);
                        await _context.SaveChangesAsync();
                        TempData["SuccessMessage"] = "Film berhasil diperbarui!";
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!FilmExists(film.Id))
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
                return View(film);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error updating film with ID: {Id}", id);
                ModelState.AddModelError("", "Terjadi kesalahan saat memperbarui data. Silakan coba lagi.");
                return View(film);
            }
        }

        // GET: Films/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            try
            {
                var film = await _context.Films
                    .FirstOrDefaultAsync(m => m.Id == id);

                if (film == null)
                {
                    return NotFound();
                }

                return View(film);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving film for delete with ID: {Id}", id);
                return View("Error");
            }
        }

        // POST: Films/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                var film = await _context.Films.FindAsync(id);
                if (film != null)
                {
                    _context.Films.Remove(film);
                    await _context.SaveChangesAsync();
                    TempData["SuccessMessage"] = "Film berhasil dihapus!";
                }
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error deleting film with ID: {Id}", id);
                TempData["ErrorMessage"] = "Terjadi kesalahan saat menghapus film.";
                return RedirectToAction(nameof(Index));
            }
        }

        private bool FilmExists(int id)
        {
            return _context.Films.Any(e => e.Id == id);
        }
    }
}