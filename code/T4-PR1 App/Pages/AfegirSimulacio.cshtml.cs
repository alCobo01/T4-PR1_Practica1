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

            string simulationLine;
            string filePath = "Files/Simulacions.csv";
            System.IO.Directory.CreateDirectory("Files");

            switch (SistemaEnergia.Tipus)
            {
                case TipusSistema.Solar:
                    SistemaSolar = (SistemaSolar)SistemaEnergia;
                    simulationLine = $"{SistemaSolar.Data};{SistemaSolar.HoresSol};{SistemaSolar.Rati};{SistemaSolar.Cost};{SistemaSolar.Preu};{SistemaSolar.CalcularEnergiaGenerada()};{SistemaSolar.CalcularCostTotal()};{SistemaSolar.CalcularPreuTotal()};{SistemaSolar.CalcularBenefici()}";
                    break;
                case TipusSistema.Eòlic:
                    SistemaEolic = (SistemaEolic)SistemaEnergia;
                    simulationLine = $"{SistemaEolic.Data};{SistemaEolic.VelocitatVent};{SistemaEolic.Rati};{SistemaEolic.Cost};{SistemaEolic.Preu};{SistemaEolic.CalcularEnergiaGenerada()};{SistemaEolic.CalcularCostTotal()};{SistemaEolic.CalcularPreuTotal()};{SistemaEolic.CalcularBenefici()}";
                    break;
                case TipusSistema.Hidroelèctric:
                    simulationLine = $"{SistemaEnergia.Data};{SistemaHidroelectric.Cabal};{SistemaEnergia.Rati};{SistemaEnergia.Cost};{SistemaEnergia.Preu};{SistemaHidroelectric.CalcularEnergiaGenerada()};{SistemaHidroelectric.CalcularCostTotal()};{SistemaHidroelectric.CalcularPreuTotal()};{SistemaHidroelectric.CalcularBenefici()}";
                    break;
                default:
                    return Page();
            }

            System.IO.File.AppendAllText(filePath, simulationLine + "\n");


            return RedirectToPage("VeureSimulacions");
        }
    }
}
