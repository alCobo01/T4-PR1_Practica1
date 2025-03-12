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
            string filePath = Path.GetFullPath(@"Files/Simulacions.csv");

            try
            {
                if (System.IO.File.Exists(filePath))
                {
                    HasData = true;
                    using var reader = new StreamReader(filePath);

                    var config = new CsvHelper.Configuration.CsvConfiguration(CultureInfo.InvariantCulture)
                    {
                        Delimiter = ";"
                    };

                    using var csv = new CsvReader(reader, config);

                    var records = csv.GetRecords<Simulacio>().ToList();
                    Simulacions.AddRange(records);
                }
                else
                {
                    HasData = false;
                }
            }
            catch (Exception)
            {
                HasData = false;
            }
        }
    }
}
