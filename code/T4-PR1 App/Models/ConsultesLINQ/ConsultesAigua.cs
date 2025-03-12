using System.Diagnostics;

namespace T4_PR1_App.Models.ConsultesLINQ
{
    public static class ConsultesAigua
    {
        public static List<ConsumAigua> GetDeuMunicipisMesConsumidors(List<ConsumAigua> consums)
        {
            return consums
                .OrderByDescending(c => c.Total)
                .Take(10)
                .ToList();
        }

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
         
        public static List<ConsumAigua> GetConsumsSospitosos(List<ConsumAigua> consums)
        {
            return consums
                .Where(c => c.Total > 99999999)
                .ToList();
        }

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
