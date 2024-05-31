using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ITI_ITI.DbContexts;
using ITI_ITI.Models;

namespace ITI_ITI.Controllers
{
    public class MyRestaurantsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MyRestaurantsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: MyRestaurants
        public async Task<IActionResult> Index()
        {
              return _context.MyRestaurants != null ? 
                          View(await _context.MyRestaurants.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.MyRestaurants'  is null.");
        }

        // GET: MyRestaurants/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.MyRestaurants == null)
            {
                return NotFound();
            }

            var myRestaurant = await _context.MyRestaurants
                .FirstOrDefaultAsync(m => m.Id == id);
            if (myRestaurant == null)
            {
                return NotFound();
            }

            return View(myRestaurant);
        }

        // GET: MyRestaurants/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: MyRestaurants/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FullName,Description,Price")] MyRestaurant myRestaurant)
        {
            if (ModelState.IsValid)
            {
                _context.Add(myRestaurant);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(myRestaurant);
        }

        // GET: MyRestaurants/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.MyRestaurants == null)
            {
                return NotFound();
            }

            var myRestaurant = await _context.MyRestaurants.FindAsync(id);
            if (myRestaurant == null)
            {
                return NotFound();
            }
            return View(myRestaurant);
        }

        // POST: MyRestaurants/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FullName,Description,Price")] MyRestaurant myRestaurant)
        {
            if (id != myRestaurant.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(myRestaurant);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MyRestaurantExists(myRestaurant.Id))
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
            return View(myRestaurant);
        }

        // GET: MyRestaurants/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.MyRestaurants == null)
            {
                return NotFound();
            }

            var myRestaurant = await _context.MyRestaurants
                .FirstOrDefaultAsync(m => m.Id == id);
            if (myRestaurant == null)
            {
                return NotFound();
            }

            return View(myRestaurant);
        }

        // POST: MyRestaurants/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.MyRestaurants == null)
            {
                return Problem("Entity set 'ApplicationDbContext.MyRestaurants'  is null.");
            }
            var myRestaurant = await _context.MyRestaurants.FindAsync(id);
            if (myRestaurant != null)
            {
                _context.MyRestaurants.Remove(myRestaurant);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MyRestaurantExists(int id)
        {
          return (_context.MyRestaurants?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
