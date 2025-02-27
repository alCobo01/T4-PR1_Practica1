using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using T4PR1;

namespace T4_PR1_App.Pages
{
    public class AfegirSimulacioModel : PageModel
    {
        [BindProperty]
        public SistemaEnergia? SistemaEnergia { get; set; }
        public SistemaSolar? SistemaSolar { get; set; }
        public SistemaEolic? SistemaEolic { get; set; }
        public SistemaHidroelectric? SistemaHidroelectric { get; set; }


        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid) return Page();




            return RedirectToPage("Simulacions");
        }
    }
}
