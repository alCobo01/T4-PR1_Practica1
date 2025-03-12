namespace T4_PR1_App.Models.ConsultesLINQ
{
    public static class ConsultesIndicadors
    {
        public static List<IndicadorEnergetic> GetProdNetaGran(List<IndicadorEnergetic> indicadors)
        {
            return indicadors
                .Where(i => i.CDEEBC_ProdNeta > 3000)
                .OrderBy(i => i.CDEEBC_ProdNeta)
                .ToList();
        }

        public static List<IndicadorEnergetic> GetConsumGasolinaGran(List<IndicadorEnergetic> indicadors)
        {
            return indicadors
                .Where(i => i.CCAC_GasolinaAuto > 100)
                .OrderByDescending(i => i.CCAC_GasolinaAuto)
                .ToList();
        }

        public static List<IndicadorEnergetic> GetProduccioMitjaPerAny(List<IndicadorEnergetic> indicadors)
        {
            return indicadors
                .GroupBy(i => i.Data.Year)
                .Select(a => new IndicadorEnergetic
                {
                    Data = new DateTime(a.Key, 1, 1),
                    CDEEBC_ProdNeta = a.Average(i => i.CDEEBC_ProdNeta)
                })
                .ToList();
        } 

        public static List<IndicadorEnergetic> GetDemandaIproduccioGran(List<IndicadorEnergetic> indicadors)
        {
            return indicadors
                .Where(i => i.CDEEBC_DemandaElectr > 4000 && i.CDEEBC_ProdDisp > 300)
                .ToList();
        } 
    }
}
