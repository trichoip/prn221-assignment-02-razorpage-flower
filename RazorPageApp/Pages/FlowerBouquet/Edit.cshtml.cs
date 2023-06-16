using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BusinessObject.Models;

namespace RazorPageApp.Pages.FlowerBouquet
{
    public class EditModel : PageModel
    {
        private readonly FuflowerBouquetManagementContext _context;

        public EditModel(FuflowerBouquetManagementContext context)
        {
            _context = context;
        }

        [BindProperty]
        public BusinessObject.Models.FlowerBouquet FlowerBouquet { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.FlowerBouquets == null)
            {
                return NotFound();
            }

            var flowerbouquet = await _context.FlowerBouquets.Include(c => c.Supplier).Include(c => c.Category).FirstOrDefaultAsync(m => m.FlowerBouquetId == id);
            if (flowerbouquet == null)
            {
                return NotFound();
            }
            FlowerBouquet = flowerbouquet;
            ViewData["CategoryId"] = new SelectList(_context.Set<BusinessObject.Models.Category>(), "CategoryId", "CategoryName");
            ViewData["SupplierId"] = new SelectList(_context.Set<BusinessObject.Models.Supplier>(), "SupplierId", "SupplierName");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {

            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(FlowerBouquet).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FlowerBouquetExists(FlowerBouquet.FlowerBouquetId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool FlowerBouquetExists(int id)
        {
            return (_context.FlowerBouquets?.Any(e => e.FlowerBouquetId == id)).GetValueOrDefault();
        }
    }
}
