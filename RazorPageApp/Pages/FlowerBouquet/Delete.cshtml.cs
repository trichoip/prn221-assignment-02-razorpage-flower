using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BusinessObject.Models;

namespace RazorPageApp.Pages.FlowerBouquet
{
    public class DeleteModel : PageModel
    {
        private readonly FuflowerBouquetManagementContext _context;

        public DeleteModel(FuflowerBouquetManagementContext context)
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

            var flowerbouquet = await _context.FlowerBouquets.FirstOrDefaultAsync(m => m.FlowerBouquetId == id);

            if (flowerbouquet == null)
            {
                return NotFound();
            }
            else
            {
                FlowerBouquet = flowerbouquet;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.FlowerBouquets == null)
            {
                return NotFound();
            }
            var flowerbouquet = await _context.FlowerBouquets.FindAsync(id);

            if (flowerbouquet != null)
            {
                FlowerBouquet = flowerbouquet;
                _context.FlowerBouquets.Remove(FlowerBouquet);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
