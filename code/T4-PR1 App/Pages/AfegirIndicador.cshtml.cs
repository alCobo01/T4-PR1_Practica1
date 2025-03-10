using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using T4_PR1_App.Models;

namespace T4_PR1_App.Pages
{
    public class AfegirIndicadorModel : PageModel
    {
        [BindProperty]
        public IndicadorEnergetic Indicador { get; set; }
        public List<IndicadorEnergetic>? Indicadors { get; set; }
        string filePath = "Files/indicadors_energetics_cat.json";

        public void OnGet()
        {
            Indicador = new IndicadorEnergetic();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid) return Page();
            try
            {
                if (System.IO.File.Exists(filePath))
                {
                    string jsonFromFile = System.IO.File.ReadAllText(filePath);
                    var deserializedIndicadors = System.Text.Json.JsonSerializer.Deserialize<List<IndicadorEnergetic>>(jsonFromFile);
                    Indicadors = deserializedIndicadors.ToList();
                }
                else
                {
                    Indicadors = new List<IndicadorEnergetic>();
                }

                Indicadors.Add(Indicador);
                var jsonResult = System.Text.Json.JsonSerializer.Serialize(Indicadors);
                System.IO.File.WriteAllText(filePath, jsonResult);

                return RedirectToPage("VeureIndicadors");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, "Error al guardar l'arxiu JSON: " + ex.Message);
                return Page();
            }
        }
    }
}
