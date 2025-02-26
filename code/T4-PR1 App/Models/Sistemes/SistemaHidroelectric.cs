using System;
using System.Runtime.Intrinsics.X86;

namespace T4PR1
{
    public class SistemaHidroelectric : SistemaEnergia, ICalculEnergia
    {
        private const string _nom = "Hidroelèctrica";
        private const int _minim = 20;
        private const int _cabalDefecte = 25;

        private double _cabal;

        //Propietats
        public double Cabal
        {
            get { return _cabal; }
            set
            {
                if (!(value >= _minim)) throw new ArgumentException(Missatges.HidroelectricArgumentException);
                _cabal = value;
            }
        }

        //Constuctor amb major càrrega lògica
        public SistemaHidroelectric(DateTime data, double cabal, float rati, float cost, float preu)
        {
            Data = data;
            Tipus = _nom;
            Cabal = cabal;
            Rati = rati;
            Cost = cost;
            Preu = preu;
        }

        //Constructor amb menor càrrega lògica
        public SistemaHidroelectric()
        {
            Data = DateTime.Now;
            Tipus = _nom;
            Cabal = _cabalDefecte;
        }

        //Mètodes de la classe
        /// <summary>
        /// Calcula l'energia generada pel sistema hidroelèctric.
        /// </summary>
        /// <returns>
        /// Retorna l'energia calculada en kWh, arrodonida a tres decimals.
        /// </returns>
        public override double CalculEnergia() => Math.Round(Cabal * 9.8 * 0.8, 3);
        
        /// <summary>
        /// Retorna una representació en cadena de l'objecte SistemaHidroelectric.
        /// </summary>
        /// <returns>Una cadena que representa l'objecte actual.</returns>
        public override string ToString() => $"SistemaHidroelectric: Data={Data}, Tipus={Tipus}, Cabal={Cabal}";
    }
}
