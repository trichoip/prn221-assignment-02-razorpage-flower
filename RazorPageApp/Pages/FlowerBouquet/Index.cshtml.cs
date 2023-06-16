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
    public class IndexModel : PageModel
    {
        private readonly FuflowerBouquetManagementContext _context;

        public IndexModel(FuflowerBouquetManagementContext context)
        {
            _context = context;
        }

        public IList<BusinessObject.Models.FlowerBouquet> FlowerBouquet { get; set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.FlowerBouquets != null)
            {
                FlowerBouquet = await _context.FlowerBouquets
                .Include(f => f.Category)
                .Include(f => f.Supplier).ToListAsync();
            }
        }
    }
}
