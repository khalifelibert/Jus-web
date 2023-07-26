using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApp0.Data;
using WebApp0.Model;

namespace WebApp0.Pages.Type
{
    public class EditModel : PageModel
    {
        private readonly WebApp0.Data.ProduitContext _context;

        public EditModel(WebApp0.Data.ProduitContext context)
        {
            _context = context;
        }

        [BindProperty]
        public ProduitQl ProduitQl { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.ProduitQls == null)
            {
                return NotFound();
            }

            var produitql =  await _context.ProduitQls.FirstOrDefaultAsync(m => m.Id == id);
            if (produitql == null)
            {
                return NotFound();
            }
            ProduitQl = produitql;
           ViewData["ProduitId"] = new SelectList(_context.Produits, "Id", "Id");
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

            _context.Attach(ProduitQl).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProduitQlExists(ProduitQl.Id))
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

        private bool ProduitQlExists(int id)
        {
          return (_context.ProduitQls?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
