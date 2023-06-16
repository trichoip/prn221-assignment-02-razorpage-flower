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
    public class DetailsModel : PageModel
    {
        private readonly FuflowerBouquetManagementContext _context;

        public DetailsModel(FuflowerBouquetManagementContext context)
        {
            _context = context;
        }

        public BusinessObject.Models.FlowerBouquet FlowerBouquet { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.FlowerBouquets == null)
            {
                return NotFound();
            }

            var flowerbouquet = await _context.FlowerBouquets.Include(f => f.Category).Include(f => f.Supplier).FirstOrDefaultAsync(m => m.FlowerBouquetId == id);
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
    }
}
