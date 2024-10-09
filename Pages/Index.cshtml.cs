using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Form_Data.Data;
using Form_Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace Form_Data.Pages
{
    [Authorize]
    public class IndexModel : PageModel
    {
        // set private properties
        private readonly ILogger<IndexModel> _logger;
        private readonly ApplicationDbContext _context;
        // perform DI

        public IndexModel(ILogger<IndexModel> logger, ApplicationDbContext context)
        {
            _logger = logger;
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

