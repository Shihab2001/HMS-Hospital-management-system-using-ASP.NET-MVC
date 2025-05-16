using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HMS.Models;

namespace HMS.Controllers
{
    public class DrugStoresController : Controller
    {
        private readonly HmsContext _context;

        public DrugStoresController(HmsContext context)
        {
            _context = context;
        }

        
        public async Task<IActionResult> Index()
        {
            return View(await _context.DrugStores.ToListAsync());
        }

        
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var drugStore = await _context.DrugStores
                .FirstOrDefaultAsync(m => m.Id == id);
            if (drugStore == null)
            {
                return NotFound();
            }

            return View(drugStore);
        }

       
        public IActionResult Create()
        {
            return View();
        }

       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Price,DGroup,Expire,InStock")] DrugStore drugStore)
        {
            if (ModelState.IsValid)
            {
                _context.Add(drugStore);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(drugStore);
        }


        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var drugStore = await _context.DrugStores.FindAsync(id);
            if (drugStore == null)
            {
                return NotFound();
            }
            return View(drugStore);
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Price,DGroup,Expire,InStock")] DrugStore drugStore)
        {
            if (id != drugStore.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(drugStore);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DrugStoreExists(drugStore.Id))
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
            return View(drugStore);
        }


        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var drugStore = await _context.DrugStores
                .FirstOrDefaultAsync(m => m.Id == id);
            if (drugStore == null)
            {
                return NotFound();
            }

            return View(drugStore);
        }

        
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var drugStore = await _context.DrugStores.FindAsync(id);
            if (drugStore != null)
            {
                _context.DrugStores.Remove(drugStore);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DrugStoreExists(int id)
        {
            return _context.DrugStores.Any(e => e.Id == id);
        }
    }
}
