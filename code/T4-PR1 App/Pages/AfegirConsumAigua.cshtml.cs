using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.IO;
using System.Xml.Linq;
using T4_PR1_App.Models;

namespace T4_PR1_App.Pages
{
    public class AfegirConsumAiguaModel : PageModel
    {
        [BindProperty]
        public ConsumAigua ConsumAigua { get; set; }

        readonly string filePath = "Files/consum_aigua_cat_per_comarques.xml";

        public void OnGet()
        {
            ConsumAigua = new ConsumAigua();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid) return Page();

            try
            {
                XDocument doc;

                if (System.IO.File.Exists(filePath))
                {
                    doc = XDocument.Load(filePath);
                }
                else
                {
                    doc = new XDocument(
                        new XDeclaration("1.0", "utf-8", "yes"),
                        new XElement("Consums")
                    );
                }

                XElement newConsum = new XElement("Consum",
                    new XElement("Any", ConsumAigua.Any),
                    new XElement("CodiComarca", ConsumAigua.CodiComarca),
                    new XElement("Comarca", ConsumAigua.Comarca),
                    new XElement("Poblacio", ConsumAigua.Poblacio),
                    new XElement("DomesticXarxa", ConsumAigua.DomesticXarxa),
                    new XElement("ActivitatsEconomiquesIFontsPropies", ConsumAigua.ActivitatsEconomiquesIFontsPropies),
                    new XElement("Total", ConsumAigua.Total),
                    new XElement("ConsumDomesticPerCapita", ConsumAigua.ConsumDomesticPerCapita)
                );

                doc.Root.Add(newConsum);

                doc.Save(filePath);

                return RedirectToPage("VeureConsumAigua");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, "Error al guardar l'arxiu XML: " + ex.Message);
                return Page();
            }
        }
    }
}
