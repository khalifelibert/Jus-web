using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebApp0.Data;
using WebApp0.Model;

namespace WebApp0.Pages.Produits
{
    public class IndexModel : PageModel
    {
        private readonly WebApp0.Data.ProduitContext _context;

        public IndexModel(WebApp0.Data.ProduitContext context)
        {
            _context = context;
        }

        public IList<Produit> Produit { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Produits != null)
            {
                Produit = await _context.Produits.ToListAsync();
            }
        }
    }
}
