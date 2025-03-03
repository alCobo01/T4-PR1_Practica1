using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using T4PR1;
using CsvHelper;
using System.Globalization;

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
            SistemaEnergia sistemaEspecific;
            Simulacio simulacio;

            ModelState.Clear();
            switch (SistemaEnergia.Tipus)
            {
                case TipusSistema.Solar:
                    SistemaSolar.Data = DateTime.Now;
                    SistemaSolar.Rati = SistemaEnergia.Rati;
                    SistemaSolar.Cost = SistemaEnergia.Cost;
                    SistemaSolar.Preu = SistemaEnergia.Preu;

                    if (!TryValidateModel(SistemaSolar)) return Page();

                    simulacio = new Simulacio
                    {
                        Tipus = SistemaEnergia.Tipus.Value,
                        Data = SistemaSolar.Data,
                        Dada = SistemaSolar.HoresSol,
                        Rati = SistemaSolar.Rati,
                        Cost = SistemaSolar.Cost,
                        Preu = SistemaSolar.Preu,
                        EnergiaGenerada = SistemaSolar.CalcularEnergiaGenerada(),
                        CostTotal = SistemaSolar.CalcularCostTotal(),
                        PreuTotal = SistemaSolar.CalcularPreuTotal(),
                        Benefici = SistemaSolar.CalcularBenefici()
                    };
                    break;
                case TipusSistema.Eòlic:
                    SistemaEolic.Data = DateTime.Now;
                    SistemaEolic.Rati = SistemaEnergia.Rati;
                    SistemaEolic.Cost = SistemaEnergia.Cost;
                    SistemaEolic.Preu = SistemaEnergia.Preu;

                    if (!TryValidateModel(SistemaEolic)) return Page();

                    simulacio = new Simulacio
                    {
                        Tipus = SistemaEnergia.Tipus.Value,
                        Data = SistemaEolic.Data,
                        Dada = SistemaEolic.VelocitatVent,
                        Rati = SistemaEolic.Rati,
                        Cost = SistemaEolic.Cost,
                        Preu = SistemaEolic.Preu,
                        EnergiaGenerada = SistemaEolic.CalcularEnergiaGenerada(),
                        CostTotal = SistemaEolic.CalcularCostTotal(),
                        PreuTotal = SistemaEolic.CalcularPreuTotal(),
                        Benefici = SistemaEolic.CalcularBenefici()
                    };
                    break;
                case TipusSistema.Hidroelèctric:
                    SistemaHidroelectric.Data = DateTime.Now;
                    SistemaHidroelectric.Rati = SistemaEnergia.Rati;
                    SistemaHidroelectric.Cost = SistemaEnergia.Cost;
                    SistemaHidroelectric.Preu = SistemaEnergia.Preu;

                    if (!TryValidateModel(SistemaHidroelectric)) return Page();

                    simulacio = new Simulacio
                    {
                        Tipus = SistemaEnergia.Tipus.Value,
                        Data = SistemaHidroelectric.Data,
                        Dada = SistemaHidroelectric.Cabal,
                        Rati = SistemaHidroelectric.Rati,
                        Cost = SistemaHidroelectric.Cost,
                        Preu = SistemaHidroelectric.Preu,
                        EnergiaGenerada = SistemaHidroelectric.CalcularEnergiaGenerada(),
                        CostTotal = SistemaHidroelectric.CalcularCostTotal(),
                        PreuTotal = SistemaHidroelectric.CalcularPreuTotal(),
                        Benefici = SistemaHidroelectric.CalcularBenefici()
                    };
                    break;
                default:
                    return Page();
            }

            string filePath = "Files/Simulacions.csv";
            System.IO.Directory.CreateDirectory("Files");

            var config = new CsvHelper.Configuration.CsvConfiguration(CultureInfo.InvariantCulture)
            {
                HasHeaderRecord = !System.IO.File.Exists(filePath),
                Delimiter = ";"
            };

            using (var stream = new StreamWriter(filePath, append: true))
            using (var csv = new CsvWriter(stream, config))
            {
                if (config.HasHeaderRecord)
                {
                    csv.WriteHeader<Simulacio>();
                    csv.NextRecord();
                }
                csv.WriteRecord(simulacio);
                csv.NextRecord();
            }

            return RedirectToPage("VeureSimulacions");
        }

    }
}
