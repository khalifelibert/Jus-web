using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebApp0.Data;
using WebApp0.Model;

namespace WebApp0.Pages.Type
{
    public class CreateModel : PageModel
    {
        private readonly WebApp0.Data.ProduitContext _context;

        public CreateModel(WebApp0.Data.ProduitContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["ProduitId"] = new SelectList(_context.Produits, "Id", "Id");
            return Page();
        }

        [BindProperty]
        public ProduitQl ProduitQl { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.ProduitQls == null || ProduitQl == null)
            {
                return Page();
            }

            _context.ProduitQls.Add(ProduitQl);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
