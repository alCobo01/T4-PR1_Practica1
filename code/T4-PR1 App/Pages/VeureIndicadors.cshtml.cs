using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using T4_PR1_App.Models;
using CsvHelper;
using System.Globalization;

namespace T4_PR1_App.Pages
{
    public class VeureIndicadorsModel : PageModel
    {
        public bool HasData { get; set; }
        public List<IndicadorEnergetic> Indicadors { get; set; }
        public void OnGet()
        {
            Indicadors = new List<IndicadorEnergetic>();
            string filePath = "Files/indicadors_energetics_cat.csv";

            try
            {
                if (System.IO.File.Exists(filePath))
                {
                    HasData = true;
                    using var reader = new StreamReader(filePath);
                    using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);
                    var records = csv.GetRecords<IndicadorEnergetic>().ToList();
                    Indicadors.AddRange(records);
                }
                else { HasData = false; }
            }
            catch (Exception) { HasData = false; }
        }
    }
}
