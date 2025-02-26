using System;
using System.Reflection.Emit;

namespace T4PR1
{
    public class SistemaSolar : SistemaEnergia, ICalculEnergia
    {
        private const string _nom = "Solar";
        private const int _minim = 1;
        private const int _horesDefecte = 5;

        private double _horesSol;

        //Propietats
        public double HoresSol
        {
            get { return _horesSol; }
            set
            {
                if (!(value >= _minim)) throw new ArgumentException(Missatges.SolarArgumentException);
                _horesSol = value;
            }
        }

        //Constructor amb major càrrega lògica
        public SistemaSolar(DateTime data, double horesSol, float rati, float cost, float preu)
        {
            Data = data;
            Tipus = _nom;
            HoresSol = horesSol;
            Rati = rati;
            Cost = cost;
            Preu = preu;
        }

        //Constructor amb menor càrrega lògica
        public SistemaSolar() : this(DateTime.Now, _horesDefecte, default, default, default) { }
 

        //Mètodes de la classe
        /// <summary>
        /// Calcula l'energia generada pel sistema solar.
        /// </summary>
        /// <returns>Retorna l'energia calculada en kWh.</returns>
        public override double CalculEnergia() => HoresSol * 1.5;

        /// <summary>
        /// Retorna una cadena que representa l'objecte SistemaSolar.
        /// </summary>
        /// <returns>Una cadena que representa l'objecte actual.</returns>
        public override string ToString() => $"SistemaSolar [Data={Data}, Tipus={Tipus}, HoresSol={HoresSol}]";


    }
}
