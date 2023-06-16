using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BusinessObject.Models;

namespace RazorPageApp.Pages.Category
{
    public class IndexModel : PageModel
    {
        private readonly FuflowerBouquetManagementContext _context;

        public IndexModel(FuflowerBouquetManagementContext context)
        {
            _context = context;
        }

        public IList<BusinessObject.Models.Category> Category { get; set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Categories != null)
            {
                Category = await _context.Categories.ToListAsync();
            }
        }
    }
}
