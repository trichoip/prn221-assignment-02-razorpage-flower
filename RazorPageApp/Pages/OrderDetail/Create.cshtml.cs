using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using BusinessObject.Models;

namespace RazorPageApp.Pages.OrderDetail
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
            ViewData["FlowerBouquetId"] = new SelectList(_context.FlowerBouquets, "FlowerBouquetId", "Description");
            ViewData["OrderId"] = new SelectList(_context.Orders, "OrderId", "OrderId");
            return Page();
        }

        [BindProperty]
        public BusinessObject.Models.OrderDetail OrderDetail { get; set; } = default!;

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid || _context.OrderDetails == null || OrderDetail == null)
            {
                return Page();
            }

            _context.OrderDetails.Add(OrderDetail);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
