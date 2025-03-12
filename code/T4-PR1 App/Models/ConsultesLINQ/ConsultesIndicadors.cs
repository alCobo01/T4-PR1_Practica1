namespace T4_PR1_App.Models.ConsultesLINQ
{
    public static class ConsultesIndicadors
    {
        /// <summary>
        /// Retorna una llista d'objectes IndicadorEnergetic on la propietat CDEEBC_ProdNeta és superior a 3000, ordenada per CDEEBC_ProdNeta.
        /// </summary>
        /// <param name="indicadors">La col·lecció d'objectes IndicadorEnergetic a consultar.</param>
        /// <returns>Una llista d'IndicadorEnergetic que compleixen el criteri de filtre.</returns>
        public static List<IndicadorEnergetic> GetProdNetaGran(List<IndicadorEnergetic> indicadors)
        {
            return indicadors
                .Where(i => i.CDEEBC_ProdNeta > 3000)
                .OrderBy(i => i.CDEEBC_ProdNeta)
                .ToList();
        }

        /// <summary>
        /// Retorna una llista d'objectes IndicadorEnergetic on la propietat CCAC_GasolinaAuto és superior a 100, ordenada de manera descendent per CCAC_GasolinaAuto.
        /// </summary>
        /// <param name="indicadors">La col·lecció d'objectes IndicadorEnergetic a consultar.</param>
        /// <returns>Una llista d'IndicadorEnergetic que compleixen el criteri de filtre.</returns>
        public static List<IndicadorEnergetic> GetConsumGasolinaGran(List<IndicadorEnergetic> indicadors)
        {
            return indicadors
                .Where(i => i.CCAC_GasolinaAuto > 100)
                .OrderByDescending(i => i.CCAC_GasolinaAuto)
                .ToList();
        }

        /// <summary>
        /// Retorna una llista d'objectes IndicadorEnergetic amb el valor mitjà de CDEEBC_ProdNeta per any.
        /// </summary>
        /// <param name="indicadors">La col·lecció d'objectes IndicadorEnergetic a consultar.</param>
        /// <returns>Una llista d'IndicadorEnergetic que representen la producció neta mitjana per any.</returns>
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

        /// <summary>
        /// Retorna una llista d'objectes IndicadorEnergetic on la propietat CDEEBC_DemandaElectr és superior a 4000 
        /// i la propietat CDEEBC_ProdDisp és superior a 300.
        /// </summary>
        /// <param name="indicadors">La col·lecció d'objectes IndicadorEnergetic a consultar.</param>
        /// <returns>Una llista d'IndicadorEnergetic que compleixen els criteris de demanda i disponibilitat de producció.</returns>
        public static List<IndicadorEnergetic> GetDemandaIproduccioGran(List<IndicadorEnergetic> indicadors)
        {
            return indicadors
                .Where(i => i.CDEEBC_DemandaElectr > 4000 && i.CDEEBC_ProdDisp > 300)
                .ToList();
        }
    }
}
