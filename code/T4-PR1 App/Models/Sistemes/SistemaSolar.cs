using System;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace T4PR1
{
    public class SistemaSolar : SistemaEnergia, ICalculSimulacio
    {
        private const int _minim = 1;
        private const int _horesDefecte = 5;

        //Propietats
        private double _horesSol;

        [Required(ErrorMessage = Missatges.SolarObligatori)]
        [Range(_minim, double.MaxValue, ErrorMessage = Missatges.SolarMinim)]
        public double HoresSol
        {
            get { return _horesSol; }
            set
            {
                if (!(value >= _minim)) throw new ArgumentException(Missatges.SolarMinim);
                _horesSol = value;
            }
        }

        //Constructor amb major càrrega lògica
        public SistemaSolar(DateTime data, double horesSol, float rati, float cost, float preu)
        {
            Data = data;
            Tipus = TipusSistema.Solar;
            HoresSol = horesSol;
            Rati = rati;
            Cost = cost;
            Preu = preu;
        }

        //Constructor amb menor càrrega lògica
        public SistemaSolar() : this(DateTime.Now, _horesDefecte, 0, 0, 0) { }

        //Mètodes de la classe
        /// <summary> Calcula l'energia generada pel sistema solar. </summary>
        /// <returns> Retorna l'energia calculada en kWh </returns>
        public override double CalcularEnergiaGenerada() => HoresSol * Rati;

        /// <summary> Retorna una representació en cadena de l'objecte SistemaSolar. </summary>
        /// <returns>Una cadena que representa l'objecte actual.</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Sistema Solar:");
            sb.AppendLine($"Data: {Data}");
            sb.AppendLine($"Hores de sol: {HoresSol}h");
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
