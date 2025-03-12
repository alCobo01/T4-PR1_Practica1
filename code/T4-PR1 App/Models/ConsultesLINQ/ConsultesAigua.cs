using System.Diagnostics;

namespace T4_PR1_App.Models.ConsultesLINQ
{
    public static class ConsultesAigua
    {
        /// <summary>
        /// Retorna els deu municipis amb el major consum d'aigua.
        /// </summary>
        /// <param name="consums">Llista de consums d'aigua.</param>
        /// <returns>Llista amb els 10 municipis amb el consum més alt.</returns>
        public static List<ConsumAigua> GetDeuMunicipisMesConsumidors(List<ConsumAigua> consums)
        {
            return consums
                .OrderByDescending(c => c.Total)
                .Take(10)
                .ToList();
        }

        /// <summary>
        /// Calcula el consum mitjà d'aigua per comarca.
        /// </summary>
        /// <param name="consums">Llista de consums d'aigua.</param>
        /// <returns>Llista amb el consum mitjà per comarca, ordenada pel codi de comarca.</returns>
        public static List<ConsumAigua> GetConsumMitjaPerComarca(List<ConsumAigua> consums)
        {
            return consums
                .GroupBy(c => c.CodiComarca)
                .Select(g => new ConsumAigua
                {
                    CodiComarca = g.Key,
                    Comarca = g.First().Comarca,
                    Total = g.Average(c => c.Total)
                })
                .OrderBy(c => c.CodiComarca)
                .ToList();
        }

        /// <summary>
        /// Filtra i retorna els consums d'aigua considerats sospitosos.
        /// </summary>
        /// <param name="consums">Llista de consums d'aigua.</param>
        /// <returns>Llista amb els consums que superen el llindar considerat sospitós.</returns>
        public static List<ConsumAigua> GetConsumsSospitosos(List<ConsumAigua> consums)
        {
            return consums
                .Where(c => c.Total > 99999999)
                .ToList();
        }

        /// <summary>
        /// Retorna els municipis amb tendència creixent en el consum d'aigua durant els últims cinc anys.
        /// </summary>
        /// <param name="consums">Llista de consums d'aigua.</param>
        /// <returns>Llista de noms de municipis que han mostrat una millora anual en el consum d'aigua.</returns>
        public static List<string> GetMunicipisAmbTendenciaCreixent(List<ConsumAigua> consums)
        {
            var anyActual = DateTime.Now.Year;
            var anyInici = anyActual - 5;

            return consums
                .Where(c => c.Any >= anyInici)
                .GroupBy(c => c.Poblacio)
                .Where(g => g.OrderBy(c => c.Any)
                             .Select((c, i) => new { c.Any, Index = i })
                             .All(x => x.Index == 0 || x.Any > g.ElementAt(x.Index - 1).Any))
                .Select(g => g.Key)
                .ToList();
        }
    }
}
