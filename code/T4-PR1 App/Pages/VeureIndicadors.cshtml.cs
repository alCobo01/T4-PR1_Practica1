using Microsoft.AspNetCore.Mvc.RazorPages;
using CsvHelper;
using System.Globalization;
using T4_PR1_App.Models.ConsultesLINQ;

namespace T4_PR1_App.Pages
{
    public class VeureIndicadorsModel : PageModel
    {
        public bool HasData { get; set; }
        public List<IndicadorEnergetic> Indicadors { get; set; }
        public List<IndicadorEnergetic> ProduccionsNetesGrans { get; set; }
        public List<IndicadorEnergetic> ConsumsGasolinaGrans { get; set; }
        public List<IndicadorEnergetic> ProduccionsMitjaPerAny { get; set; }
        public List<IndicadorEnergetic> DemandesIproduccionsGrans { get; set; }

        public void OnGet()
        {
            Indicadors = new List<IndicadorEnergetic>();

            // Llegir el fitxer CSV
            string filePathCSV = "Files/indicadors_energetics_cat.csv";
            try
            {
                if (System.IO.File.Exists(filePathCSV))
                {
                    HasData = true;
                    
                    using var reader = new StreamReader(filePathCSV);
                    using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);

                    var records = csv.GetRecords<IndicadorEnergetic>().ToList();
                    Indicadors.AddRange(records);
                }
                else { HasData = false; }
            }
            catch (Exception ex) {
                Console.WriteLine(ex.Message);
                HasData = false; }

            // Llegir el fitxer CSV
            string filePathJSON = "Files/indicadors_energetics_cat.json";
            try
            {
                if (System.IO.File.Exists(filePathJSON))
                {
                    HasData = true;

                    string jsonFromFile = System.IO.File.ReadAllText(filePathJSON);
                    var records = System.Text.Json.JsonSerializer.Deserialize<List<IndicadorEnergetic>>(jsonFromFile);
                    Indicadors.AddRange(records);
                }
            }
            catch (Exception) { HasData = false; }

            // Consultes LINQ
            ProduccionsNetesGrans = ConsultesIndicadors.GetProdNetaGran(Indicadors);
            ConsumsGasolinaGrans = ConsultesIndicadors.GetConsumGasolinaGran(Indicadors);
            ProduccionsMitjaPerAny = ConsultesIndicadors.GetProduccioMitjaPerAny(Indicadors);
            DemandesIproduccionsGrans = ConsultesIndicadors.GetDemandaIproduccioGran(Indicadors);

        }




    }
}
