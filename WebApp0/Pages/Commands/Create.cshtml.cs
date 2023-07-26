using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebApp0.Data;
using WebApp0.Model;

namespace WebApp0.Pages.Commands
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
            return Page();
        }

        [BindProperty]
        public Command Command { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Commands == null || Command == null)
            {
                return Page();
            }

            _context.Commands.Add(Command);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
