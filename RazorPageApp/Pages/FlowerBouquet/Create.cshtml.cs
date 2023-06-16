using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using BusinessObject.Models;

namespace RazorPageApp.Pages.FlowerBouquet
{
    public class CreateModel : PageModel
    {
        private readonly FuflowerBouquetManagementContext _context;

        public CreateModel(FuflowerBouquetManagementContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["CategoryId"] = new SelectList(_context.Set<BusinessObject.Models.Category>(), "CategoryId", "CategoryName");
            ViewData["SupplierId"] = new SelectList(_context.Set<BusinessObject.Models.Supplier>(), "SupplierId", "SupplierName");
            return Page();
        }

        [BindProperty]
        public BusinessObject.Models.FlowerBouquet FlowerBouquet { get; set; } = default!;

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid || _context.FlowerBouquets == null || FlowerBouquet == null)
            {
                return Page();
            }

            _context.FlowerBouquets.Add(FlowerBouquet);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
