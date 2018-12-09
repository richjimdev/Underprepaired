using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Underprepaired.Data;

namespace Underprepaired.Pages.Admin
{
    [Authorize(Policy = "AdminOnly")]
    public class AdminPanelModel : PageModel
    {
        private UnderprepairedDbContext _context;

        [BindProperty]
        public Underprepaired.Models.Product Products { get; set; }

        public AdminPanelModel(UnderprepairedDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> OnGet()
        {
            var products = await _context.Orders.ToListAsync();

            return Page();
        }
    }
}