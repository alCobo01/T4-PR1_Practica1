using System.ComponentModel.DataAnnotations;
using T4_PR1_App.Models.Missatges;

namespace T4PR1
{
    public enum TipusSistema
    {
        Hidroelèctric,
        Eòlic,
        Solar
    }

    public class SistemaEnergia : ICalculSimulacio
    {
        [Required(ErrorMessage = MissatgesSistemes.RatiObligatori)]
        public float Rati { get; set; }

        [Required(ErrorMessage = MissatgesSistemes.CostObligatori)]
        public float Cost { get; set; }

        [Required(ErrorMessage = MissatgesSistemes.PreuObligatori)]
        public float Preu { get; set; }

        public DateTime Data { get; set; }

        [Required(ErrorMessage = MissatgesSistemes.TipusObligatori)]
        public TipusSistema? Tipus { get; set; }

        //Métodes de la classe
        public virtual double CalcularEnergiaGenerada() => 0;

        /// <summary> Calcula el cost total de l'energia generada pel sistema eòlic. </summary>
        /// <returns> Retorna el cost total del sistema</returns>
        public double CalcularCostTotal() => Math.Round(CalcularEnergiaGenerada() * Cost, 2);

        /// <summary> Calcula el preu total de l'energia generada pel sistema eòlic. </summary>
        /// <returns> Retorna el preu total del sistema</returns>
        public double CalcularPreuTotal() => Math.Round(CalcularEnergiaGenerada() * Preu, 2);

        /// <summary> Calcula el benefici total de l'energia generada pel sistema eòlic. </summary>
        /// <returns> Retorna el benefici total del sistema</returns>
        public double CalcularBenefici() => Math.Round(CalcularPreuTotal() - CalcularCostTotal(), 2);

    }
}
