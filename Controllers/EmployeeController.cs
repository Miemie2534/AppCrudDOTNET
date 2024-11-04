using AppCrudDOTNET.Data;
using AppCrudDOTNET.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AppCrudDOTNET.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EmployeeController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> ListEmployee()
        {
            return View(await _context.Employee.ToListAsync());
        }

        public IActionResult CreateEmployee()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateEmployee(Employee model)
        {
            var db = await _context.Employee.AddAsync(model);

            if (db == null)
            {
                return NotFound();
            }
            await _context.SaveChangesAsync();
            return RedirectToAction("ListEmployee");
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var emp = await _context.Employee.FindAsync(id);
            if (emp == null)
            {
                return NotFound();
            }
            return View(emp);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Employee model)
        {
           if (!ModelState.IsValid)
            {
                _context.Employee.Update(model);
                await _context.SaveChangesAsync();
                return RedirectToAction("ListEmployee");
            }
            return View(model);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == 0)
            {
                return NotFound();
            }
            var emp = await _context.Employee.FindAsync(id);
            if (emp == null)
            {
                return NotFound();
            }
            _context.Employee.Remove(emp);
            await _context.SaveChangesAsync();

            return RedirectToAction("ListEmployee");
        }
    }
}
