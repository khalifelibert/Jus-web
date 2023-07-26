﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebApp0.Data;
using WebApp0.Model;

namespace WebApp0.Pages.Type
{
    public class DeleteModel : PageModel
    {
        private readonly WebApp0.Data.ProduitContext _context;

        public DeleteModel(WebApp0.Data.ProduitContext context)
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

            var produitql = await _context.ProduitQls.FirstOrDefaultAsync(m => m.Id == id);

            if (produitql == null)
            {
                return NotFound();
            }
            else 
            {
                ProduitQl = produitql;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.ProduitQls == null)
            {
                return NotFound();
            }
            var produitql = await _context.ProduitQls.FindAsync(id);

            if (produitql != null)
            {
                ProduitQl = produitql;
                _context.ProduitQls.Remove(ProduitQl);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
