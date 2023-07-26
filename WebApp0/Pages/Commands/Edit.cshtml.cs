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

namespace WebApp0.Pages.Commands
{
    public class EditModel : PageModel
    {
        private readonly WebApp0.Data.ProduitContext _context;

        public EditModel(WebApp0.Data.ProduitContext context)
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

            var command =  await _context.Commands.FirstOrDefaultAsync(m => m.Id == id);
            if (command == null)
            {
                return NotFound();
            }
            Command = command;
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

            _context.Attach(Command).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CommandExists(Command.Id))
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

        private bool CommandExists(int id)
        {
          return (_context.Commands?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
