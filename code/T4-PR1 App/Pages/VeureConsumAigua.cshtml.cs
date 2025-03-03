using CsvHelper;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Globalization;
using T4_PR1_App.Models;
using T4PR1;

namespace T4_PR1_App.Pages
{
    public class VeureConsumAiguaModel : PageModel
    {
        public bool HasData { get; set; }
        public List<ConsumAigua> Consums { get; set; }
        public void OnGet()
        {
            Consums = new List<ConsumAigua>();
            string filePath = "Files/consum_aigua_cat_per_comarques.csv";

            try
            {
                if (System.IO.File.Exists(filePath))
                {
                    HasData = true;
                    using var reader = new StreamReader(filePath);

                    using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);

                    var records = csv.GetRecords<ConsumAigua>().ToList();
                    Consums.AddRange(records);
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
