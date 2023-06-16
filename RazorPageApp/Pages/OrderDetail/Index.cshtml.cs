using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BusinessObject.Models;

namespace RazorPageApp.Pages.OrderDetail
{
    public class IndexModel : PageModel
    {
        private readonly FuflowerBouquetManagementContext _context;

        public IndexModel(FuflowerBouquetManagementContext context)
        {
            _context = context;
        }

        public IList<BusinessObject.Models.OrderDetail> OrderDetail { get; set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.OrderDetails != null)
            {
                OrderDetail = await _context.OrderDetails
                .Include(o => o.FlowerBouquet).ToListAsync();
            }
        }
    }
}
