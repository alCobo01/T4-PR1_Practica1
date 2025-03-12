using System;
using System.ComponentModel.DataAnnotations;
using System.Text;
using T4_PR1_App.Models.Missatges;

namespace T4PR1
{
    public class SistemaEolic : SistemaEnergia, ICalculSimulacio
    {
        private const int _minim = 5;
        private const int _velocitatDefecte = 10;

        //Propietats
        private double _velocitatVent;

        [Required(ErrorMessage = MissatgesSistemes.EolicObligatori)]
        [Range(_minim, double.MaxValue, ErrorMessage = MissatgesSistemes.EolicMinim)]
        public double VelocitatVent
        {
            get { return _velocitatVent; }
            set
            {
                if ((value <= _minim)) throw new ArgumentException(MissatgesSistemes.EolicMinim);
                _velocitatVent = value;
            }
        }

        //Constuctor amb major càrrega lògica
        public SistemaEolic(DateTime data, double velocitatVent, float rati, float cost, float preu)
        {
            Data = data;
            Tipus = TipusSistema.Eòlic;
            VelocitatVent = velocitatVent;
            Rati = rati;
            Cost = cost;
            Preu = preu;
        }

        //Constructor amb menor càrrega lògica
        public SistemaEolic() : this(DateTime.Now, _velocitatDefecte, 0, 0, 0) { }


        //Mètodes de la classe
        /// <summary> Calcula l'energia generada pel sistema eòlic. </summary>
        /// <returns> Retorna l'energia calculada en kWh. </returns>
        public override double CalcularEnergiaGenerada() => Math.Pow(VelocitatVent, 3) * Rati;

        /// <summary> Retorna una representació en cadena de l'objecte SistemaEolic. </summary>
        /// <returns>Una cadena que representa l'objecte actual.</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Sistema Eòlic:");
            sb.AppendLine($"Data: {Data}");
            sb.AppendLine($"Velocitat del vent: {VelocitatVent} m/s");
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