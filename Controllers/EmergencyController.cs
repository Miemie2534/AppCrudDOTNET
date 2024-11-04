using AppCrudDOTNET.Data;
using AppCrudDOTNET.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AppCrudDOTNET.Controllers
{
    public class EmergencyController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EmergencyController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Menu()
        {
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> ListEmer()
        {
            return View(await _context.EmerList.ToListAsync());
        }

        public IActionResult CreateEmer()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateEmer(EmerList model)
        {
            var db = await _context.EmerList.AddAsync(model);

            if (db == null)
            {
                return NotFound();
            }
            await _context.SaveChangesAsync();

            return RedirectToAction("ListEmer");
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }
            var db = await _context.EmerList.FindAsync(id);
            if (db == null)
            {
                return NotFound();
            }
            return View(db);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(EmerList model)
        {
            if (ModelState.IsValid)
            {
                _context.EmerList.Update(model);
                await _context.SaveChangesAsync();
                return RedirectToAction("ListEmer");
            }        
            return View(model);
        }



        //Delete
        public async Task<IActionResult> DeleteEmer(int id)
        {
            if(id == 0)
            {
                return NotFound();
            }
            var db = await _context.EmerList.FindAsync(id);
            if (db == null)
            {
                return NotFound();
            }
            _context.EmerList.Remove(db);
            await _context.SaveChangesAsync();

            return RedirectToAction("ListEmer");
        }
    }
}
