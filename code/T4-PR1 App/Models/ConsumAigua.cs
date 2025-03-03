using CsvHelper.Configuration.Attributes;

namespace T4_PR1_App.Models
{
    public class ConsumAigua
    {
        //Els atributs [Name] són necessaris perquè CsvHelper pugui mapejar les columnes del fitxer CSV amb les propietats de la classe.
        [Name("Any")]
        public int Any { get; set; }

        [Name("Codi comarca")]
        public string CodiComarca { get; set; }

        [Name("Comarca")]
        public string Comarca { get; set; }

        [Name("Població")]
        public string Poblacio { get; set; }

        [Name("Domèstic xarxa")]
        public double DomanesticXarxa { get; set; }

        [Name("Activitats econòmiques i fonts pròpies")]
        public double ActivitatsEconomiquesIFontsPropies { get; set; }

        [Name("Total")]
        public double Total { get; set; }

        [Name("Consum domèstic per càpita")]
        public double ConsumDomesticPerCapita { get; set; }
    }
}
