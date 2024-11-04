using AppCrudDOTNET.Data;
using AppCrudDOTNET.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace AppCrudDOTNET.Controllers
{
    public class OfferController : Controller
    {
        private readonly ApplicationDbContext _offer;

        public OfferController(ApplicationDbContext offer)
        {
            _offer = offer;
        }

        public async Task<IActionResult> OfferList()
        {
            return View(await _offer.Offer.ToListAsync());
        }

        public IActionResult OfferCreate()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> OfferCreate(Offer model)
        {   
            var db = await _offer.Offer.AddAsync(model);

            if (db == null)
            {
                return NotFound();
            }
            await _offer.SaveChangesAsync();
            return RedirectToAction("OfferList");
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var db = await _offer.Offer.FindAsync(id);
            if (db == null) 
            {
                return NotFound();
            }
            return View(db);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Offer model)
        {
            if (ModelState.IsValid)
            {
                _offer.Offer.Update(model);
                await _offer.SaveChangesAsync();
                return RedirectToAction(nameof(OfferList));
            }
            return View(model);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == 0)
            {
                return NotFound();
            }
            var db = await _offer.Offer.FindAsync(id);
            if (db == null)
            {
                return NotFound();
            }
            _offer.Offer.Remove(db);
            await _offer.SaveChangesAsync();

            return RedirectToAction("OfferList");
        }
    }
}
