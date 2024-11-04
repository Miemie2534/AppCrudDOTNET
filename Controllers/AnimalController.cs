using AppCrudDOTNET.Data;
using AppCrudDOTNET.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Drawing;

namespace AppCrudDOTNET.Controllers
{
    public class AnimalController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AnimalController(ApplicationDbContext context)
        {
            _context = context;
        }

        //GET Image
        public async Task<IActionResult> Index()
        {
            return View(await _context.Animal.ToListAsync());
        }

        public async Task<IActionResult> ShowImage(int id)
        {
            var animal = await _context.Animal.FindAsync(id);
            if (animal == null || animal.Data == null || animal.ContentType == null)
            {
                return NotFound();
            }
            return File(animal.Data, animal.ContentType);
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([FromForm] IFormFile file, [FromForm] DateTime date, [FromForm] string name, [FromForm] string description, [FromForm] string area)
        {
            if (file != null && file.Length > 0)
            {
                using var stream = new MemoryStream();
                await file.CopyToAsync(stream);
               

                var animal = new Animal
                {
                    Date = date,
                    Name = name,
                    Description = description,
                    Area = area,
                    Data = stream.ToArray(),
                    ContentType = file.ContentType
                };
                _context.Animal.Add(animal);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            ModelState.AddModelError("", "Image file is required.");
            return View();
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == 0) return NotFound();           

            var animal = await _context.Animal.FindAsync(id);
            if (animal == null)
            {
                return NotFound();
            }
            return View(animal);
        }

        // POST: Animals/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [FromForm] IFormFile file, [FromForm] DateTime date, [FromForm] string name, [FromForm] string description, [FromForm] string area)
        {
            var animal = await _context.Animal.FindAsync(id);
            if (animal == null) return NotFound();

            animal.Date = date;
            animal.Name = name;
            animal.Description = description;
            animal.Area = area;

            if (file != null && file.Length > 0)
            {
                using var stream = new MemoryStream();
                await file.CopyToAsync(stream);
                animal.Data = stream.ToArray();
                animal.ContentType = file.ContentType;
            }

            _context.Entry(animal).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        // GET: Animals/Delete/5
        

        // GET: Animals/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var animal = await _context.Animal.FindAsync(id);
            if (animal == null) return NotFound();

            return File(animal.Data, animal.ContentType); // Display the image
        }

        public async Task<IActionResult> Delete(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }
            var emp = await _context.Animal.FindAsync(id);
            if (emp == null)
            {
                return NotFound();
            }
            _context.Animal.Remove(emp);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}
