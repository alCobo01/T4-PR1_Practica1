using CsvHelper;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Globalization;
using System.Xml;
using System.Xml.Linq;
using T4_PR1_App.Models;

namespace T4_PR1_App.Pages
{
    public class VeureConsumAiguaModel : PageModel
    {
        public bool HasData { get; set; }
        public List<ConsumAigua> Consums { get; set; }
        public void OnGet()
        {
            //Llegir dades del fitxer CSV
            Consums = new List<ConsumAigua>();
            string filePathCSV = "Files/consum_aigua_cat_per_comarques.csv";

            try
            {
                if (System.IO.File.Exists(filePathCSV))
                {
                    HasData = true;
                    using var reader = new StreamReader(filePathCSV);

                    using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);

                    var records = csv.GetRecords<ConsumAigua>().ToList();
                    Consums.AddRange(records);
                }
                else { HasData = false; }
            }
            catch (Exception) { HasData = false; }


            //Llegir dades del fitxer XML
            string filePathXML = "Files/consum_aigua_cat_per_comarques.xml";
            if (System.IO.File.Exists(filePathXML))
            {
                HasData = true;
                XDocument doc = XDocument.Load(filePathXML);
                var nuevosConsumAigua = doc.Root.Elements("Consum")
                    .Select(x => new ConsumAigua
                    {
                        Any = int.Parse(x.Element("Any").Value),
                        CodiComarca = x.Element("CodiComarca").Value,
                        Comarca = x.Element("Comarca").Value,
                        Poblacio = x.Element("Poblacio").Value,
                        DomesticXarxa = double.Parse(x.Element("DomesticXarxa").Value, CultureInfo.InvariantCulture),
                        ActivitatsEconomiquesIFontsPropies = double.Parse(x.Element("ActivitatsEconomiquesIFontsPropies").Value, CultureInfo.InvariantCulture),
                        Total = double.Parse(x.Element("Total").Value, CultureInfo.InvariantCulture),
                        ConsumDomesticPerCapita = double.Parse(x.Element("ConsumDomesticPerCapita").Value, CultureInfo.InvariantCulture)
                    })
                    .ToList();
                Consums.AddRange(nuevosConsumAigua);
                
            }
        }
    }
}
