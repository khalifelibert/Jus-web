using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebApp0.Data;
using WebApp0.Model;

namespace WebApp0.Pages.Commands
{
    public class DeleteModel : PageModel
    {
        private readonly WebApp0.Data.ProduitContext _context;

        public DeleteModel(WebApp0.Data.ProduitContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Command Command { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Commands == null)
            {
                return NotFound();
            }

            var command = await _context.Commands.FirstOrDefaultAsync(m => m.Id == id);

            if (command == null)
            {
                return NotFound();
            }
            else 
            {
                Command = command;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Commands == null)
            {
                return NotFound();
            }
            var command = await _context.Commands.FindAsync(id);

            if (command != null)
            {
                Command = command;
                _context.Commands.Remove(Command);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
