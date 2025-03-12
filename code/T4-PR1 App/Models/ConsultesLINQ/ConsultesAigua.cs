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

        //tengo que cambiar esta abominación. no sé que hace ni como lo hace pero funciona
        public static List<string> GetMunicipisAmbTendenciaCreixent(List<ConsumAigua> consums)
        {
            var anyActual = DateTime.Now.Year;
            var anyInici = anyActual - 5;
              
            return consums
                .Where(c => c.Any >= anyInici && c.Any <= anyActual)
                .GroupBy(c => c.Poblacio)
                .Where(g => {
                    // Ordenamos los datos por año
                    var consumsOrdenats = g.OrderBy(c => c.Any).ToList();

                    // Verificamos que haya datos para al menos 2 años distintos para poder detectar tendencia
                    if (consumsOrdenats.Select(c => c.Any).Distinct().Count() < 2)
                        return false;

                    // Comprobamos si la tendencia es creciente
                    bool tendenciaCreciente = true;
                    for (int i = 1; i < consumsOrdenats.Count; i++)
                    {
                        if (consumsOrdenats[i].Total <= consumsOrdenats[i - 1].Total)
                        {
                            tendenciaCreciente = false;
                            break;
                        }
                    }

                    return tendenciaCreciente;
                })
                .Select(g => g.Key)
                .ToList();
        }


    }
}
