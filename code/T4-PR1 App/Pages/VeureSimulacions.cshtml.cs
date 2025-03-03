using Microsoft.AspNetCore.Mvc.RazorPages;
using T4PR1;
using CsvHelper;
using System.Globalization;

namespace T4_PR1_App.Pages
{
    public class VeureSimulacionsModel : PageModel
    {
        public bool HasData { get; set; }
        public List<Simulacio> Simulacions { get; set; }
        public void OnGet()
        {
            Simulacions = new List<Simulacio>();
            string filePath = "Files/Simulacions.csv";

            try
            {
                if (System.IO.File.Exists(filePath))
                {
                    HasData = true;
                    using var reader = new StreamReader(filePath);
                    using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);

                    foreach (var simulacio in csv.GetRecords<Simulacio>())
                    {
                        Simulacions.Add(simulacio);
                    }
                }
            }
            catch (Exception)
            {
                HasData = false;
            }
        }
    }
}
