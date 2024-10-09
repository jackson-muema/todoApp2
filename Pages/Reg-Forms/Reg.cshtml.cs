using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Form_Data.Data;
using Form_Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace Form_Data.Pages
{
    [Authorize]
    public class RegModel : PageModel
    {
        // set private properties
        private readonly ILogger<RegModel> _logger;
        private readonly ApplicationDbContext _context;
        // perform DI

        public RegModel( ApplicationDbContext context)
        {
            
            _context = context;
        }
        // perform Model Binding

        [BindProperty]
        public Registration Registration { get; set; }

        public IList<Registration> Registrations { get; set; }
        public async Task OnGetAsync()
        {
            Registrations = await _context.Registrations.ToListAsync();
        }

        public IActionResult OnPost()
        {
            if(!ModelState.IsValid)
            {
                return Page(); // return form if validation fails
            }

            _context.Registrations.Add(Registration);
            _context.SaveChanges();
            return RedirectToAction("/Reg-Forms/registered");
        }
    }
}

