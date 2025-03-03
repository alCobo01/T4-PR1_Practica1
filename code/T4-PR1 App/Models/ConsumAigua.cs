using CsvHelper.Configuration.Attributes;
using System.ComponentModel.DataAnnotations;

namespace T4_PR1_App.Models
{
    public class ConsumAigua
    {
        [Name("Any")]
        [Required(ErrorMessage = "El camp Any és obligatori.")]
        public int Any { get; set; }

        [Name("Codi comarca")]
        [Required(ErrorMessage = "El camp Codi comarca és obligatori.")]
        public string CodiComarca { get; set; }

        [Name("Comarca")]
        [Required(ErrorMessage = "El camp Comarca és obligatori.")]
        public string Comarca { get; set; }

        [Name("Població")]
        [Required(ErrorMessage = "El camp Població és obligatori.")]
        public string Poblacio { get; set; }

        [Name("Domèstic xarxa")]
        [Required(ErrorMessage = "El camp Domèstic xarxa és obligatori.")]
        public double DomesticXarxa { get; set; }

        [Name("Activitats econòmiques i fonts pròpies")]
        [Required(ErrorMessage = "El camp Activitats econòmiques i fonts pròpies és obligatori.")]
        public double ActivitatsEconomiquesIFontsPropies { get; set; }

        [Name("Total")]
        [Required(ErrorMessage = "El camp Total és obligatori.")]
        public double Total { get; set; }

        [Name("Consum domèstic per càpita")]
        [Required(ErrorMessage = "El camp Consum domèstic per càpita és obligatori.")]
        public double ConsumDomesticPerCapita { get; set; }
    }
}
