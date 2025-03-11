using System;
using System.ComponentModel.DataAnnotations;
using System.Text;
using T4_PR1_App.Models.Missatges;

namespace T4PR1
{
    public class SistemaHidroelectric : SistemaEnergia, ICalculSimulacio
    {
        private const int _minim = 20;
        private const int _cabalDefecte = 25;

        //Propietats
        private double _cabal;

        [Required(ErrorMessage = MissatgesSistemes.HidroelectricObligatori)]
        [Range(_minim, double.MaxValue, ErrorMessage = MissatgesSistemes.HidroelectricMinim)]
        public double Cabal
        {
            get { return _cabal; }
            set
            {
                if (!(value >= _minim)) throw new ArgumentException(MissatgesSistemes.HidroelectricMinim);
                _cabal = value;
            }
        }

        //Constuctor amb major càrrega lògica
        public SistemaHidroelectric(DateTime data, double cabal, float rati, float cost, float preu)
        {
            Data = data;
            Tipus = TipusSistema.Hidroelèctric;
            Cabal = cabal;
            Rati = rati;
            Cost = cost;
            Preu = preu;
        }

        //Constructor amb menor càrrega lògica
        public SistemaHidroelectric() : this(DateTime.Now, _cabalDefecte, 0, 0, 0) { }

        //Mètodes de la classe
        /// <summary> Calcula l'energia generada pel sistema hidroelèctric. </summary>
        /// <returns> Retorna l'energia calculada en kWh, arrodonida a tres decimals. </returns>
        public override double CalcularEnergiaGenerada() => Math.Round(Cabal * 9.8 * Rati, 3);

        /// <summary> Retorna una representació en cadena de l'objecte SistemaHidroelectric. </summary>
        /// <returns>Una cadena que representa l'objecte actual.</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Sistema Hidroelèctric:");
            sb.AppendLine($"Data: {Data}");
            sb.AppendLine($"Cabal: {Cabal} m³/s");
            sb.AppendLine($"Rati: {Rati}");
            sb.AppendLine($"Cost: {Cost}");
            sb.AppendLine($"Preu: {Preu}");
            sb.AppendLine($"Energia calculada: {CalcularEnergiaGenerada()} kWh");
            sb.AppendLine($"Cost total: {CalcularCostTotal()}");
            sb.AppendLine($"Preu total: {CalcularPreuTotal()}");
            sb.AppendLine($"Benefici: {CalcularBenefici()}");
            return sb.ToString();
        }
    }
}
