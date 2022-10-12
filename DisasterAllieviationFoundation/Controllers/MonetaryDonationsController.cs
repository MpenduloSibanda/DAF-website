using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DisasterAllieviationFoundation.Data;
using DisasterAllieviationFoundation.Models;
using Microsoft.AspNetCore.Authorization;

namespace DisasterAllieviationFoundation.Controllers
{
    public class MonetaryDonationsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MonetaryDonationsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: MonetaryDonations
        public async Task<IActionResult> Index()
        {
            return View(await _context.MonetaryDonations.ToListAsync());
        }

        // GET: MonetaryDonations/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var monetaryDonations = await _context.MonetaryDonations
                .FirstOrDefaultAsync(m => m.ID == id);
            if (monetaryDonations == null)
            {
                return NotFound();
            }

            return View(monetaryDonations);
        }

        // GET: MonetaryDonations/Create
        [Authorize]
        public IActionResult Create()
        {
            return View();
        }

        // POST: MonetaryDonations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Date,Amount,Donor")] MonetaryDonations monetaryDonations)
        {
            if (ModelState.IsValid)
            {
                _context.Add(monetaryDonations);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(monetaryDonations);
        }

        // GET: MonetaryDonations/Edit/5
        [Authorize]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var monetaryDonations = await _context.MonetaryDonations.FindAsync(id);
            if (monetaryDonations == null)
            {
                return NotFound();
            }
            return View(monetaryDonations);
        }

        // POST: MonetaryDonations/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Date,Amount,Donor")] MonetaryDonations monetaryDonations)
        {
            if (id != monetaryDonations.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(monetaryDonations);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MonetaryDonationsExists(monetaryDonations.ID))
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
            return View(monetaryDonations);
        }

        // GET: MonetaryDonations/Delete/5
        [Authorize]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var monetaryDonations = await _context.MonetaryDonations
                .FirstOrDefaultAsync(m => m.ID == id);
            if (monetaryDonations == null)
            {
                return NotFound();
            }

            return View(monetaryDonations);
        }

        // POST: MonetaryDonations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var monetaryDonations = await _context.MonetaryDonations.FindAsync(id);
            _context.MonetaryDonations.Remove(monetaryDonations);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MonetaryDonationsExists(int id)
        {
            return _context.MonetaryDonations.Any(e => e.ID == id);
        }
    }
}
