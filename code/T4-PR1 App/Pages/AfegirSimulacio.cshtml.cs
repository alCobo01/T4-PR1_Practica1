using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using T4PR1;

namespace T4_PR1_App.Pages
{
    public class AfegirSimulacioModel : PageModel
    {
        [BindProperty]
        public SistemaEnergia SistemaEnergia { get; set; }

        [BindProperty]
        public SistemaSolar SistemaSolar { get; set; }

        [BindProperty]
        public SistemaEolic SistemaEolic { get; set; }

        [BindProperty]
        public SistemaHidroelectric SistemaHidroelectric { get; set; }

        public void OnGet()
        {
            SistemaSolar = new SistemaSolar();
            SistemaEolic = new SistemaEolic();
            SistemaHidroelectric = new SistemaHidroelectric();
            SistemaEnergia = new SistemaEnergia();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid || SistemaEnergia == null) return Page();

            SistemaEnergia sistemaEspecific;
            string simulationLine;

            switch (SistemaEnergia.Tipus)
            {
                case TipusSistema.Solar:
                    SistemaSolar.Data = SistemaEnergia.Data;
                    SistemaSolar.Rati = SistemaEnergia.Rati;
                    SistemaSolar.Cost = SistemaEnergia.Cost;
                    SistemaSolar.Preu = SistemaEnergia.Preu;

                    if (!TryValidateModel(SistemaSolar))
                    {
                        return Page();
                    }

                    simulationLine = $"{SistemaEnergia.Tipus};{SistemaSolar.Data};{SistemaSolar.HoresSol};{SistemaSolar.Rati};{SistemaSolar.Cost};{SistemaSolar.Preu};{SistemaSolar.CalcularEnergiaGenerada()};{SistemaSolar.CalcularCostTotal()};{SistemaSolar.CalcularPreuTotal()};{SistemaSolar.CalcularBenefici()}";
                    sistemaEspecific = SistemaSolar;
                    break;
                case TipusSistema.Eòlic:
                    SistemaEolic.Data = SistemaEnergia.Data;
                    SistemaEolic.Rati = SistemaEnergia.Rati;
                    SistemaEolic.Cost = SistemaEnergia.Cost;
                    SistemaEolic.Preu = SistemaEnergia.Preu;

                    if (!TryValidateModel(SistemaEolic))
                    {
                        return Page();
                    }

                    simulationLine = $"{SistemaEnergia.Tipus};{SistemaEolic.Data};{SistemaEolic.VelocitatVent};{SistemaEolic.Rati};{SistemaEolic.Cost};{SistemaEolic.Preu};{SistemaEolic.CalcularEnergiaGenerada()};{SistemaEolic.CalcularCostTotal()};{SistemaEolic.CalcularPreuTotal()};{SistemaEolic.CalcularBenefici()}";
                    sistemaEspecific = SistemaEolic;
                    break;
                case TipusSistema.Hidroelèctric:
                    SistemaHidroelectric.Data = SistemaEnergia.Data;
                    SistemaHidroelectric.Rati = SistemaEnergia.Rati;
                    SistemaHidroelectric.Cost = SistemaEnergia.Cost;
                    SistemaHidroelectric.Preu = SistemaEnergia.Preu;

                    if (!TryValidateModel(SistemaHidroelectric))
                    {
                        return Page();
                    }

                    simulationLine = $"{SistemaEnergia.Tipus};{SistemaHidroelectric.Data};{SistemaHidroelectric.Cabal};{SistemaHidroelectric.Rati};{SistemaHidroelectric.Cost};{SistemaHidroelectric.Preu};{SistemaHidroelectric.CalcularEnergiaGenerada()};{SistemaHidroelectric.CalcularCostTotal()};{SistemaHidroelectric.CalcularPreuTotal()};{SistemaHidroelectric.CalcularBenefici()}";
                    sistemaEspecific = SistemaHidroelectric;
                    break;
                default:
                    return Page();
            }

            string filePath = "Files/Simulacions.csv";
            System.IO.Directory.CreateDirectory("Files");

            if (!System.IO.File.Exists(filePath))
            {
                string header = "Tipus,Data,Dada,Rati,Cost,Preu,EnergiaGenerada,CostTotal,PreuTotal,Benefici";
                System.IO.File.WriteAllText(filePath, header + "\n");
            }

            System.IO.File.AppendAllText(filePath, simulationLine + "\n");

            return RedirectToPage("VeureSimulacions");
        }
    }
}
