using System;
using System.ComponentModel.DataAnnotations;
using System.Reflection.Emit;

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
        [Required(ErrorMessage = Missatges.RatiObligatori)]
        public float Rati { get; set; }

        [Required(ErrorMessage = Missatges.CostObligatori)]
        public float Cost { get; set; }

        [Required(ErrorMessage = Missatges.PreuObligatori)]
        public float Preu { get; set; }

        public DateTime Data { get; set; }

        [Required(ErrorMessage = Missatges.TipusObligatori)]
        public TipusSistema? Tipus { get; set; }

        //Métodes de la classe
        public virtual double CalcularEnergiaGenerada() => 0;

        /// <summary> Calcula el cost total de l'energia generada pel sistema eòlic. </summary>
        /// <returns> Retorna el cost total del sistema</returns>
        public double CalcularCostTotal() => CalcularEnergiaGenerada() * Cost;

        /// <summary> Calcula el preu total de l'energia generada pel sistema eòlic. </summary>
        /// <returns> Retorna el preu total del sistema</returns>
        public double CalcularPreuTotal() => CalcularEnergiaGenerada() * Preu;

        /// <summary> Calcula el benefici total de l'energia generada pel sistema eòlic. </summary>
        /// <returns> Retorna el benefici total del sistema</returns>
        public double CalcularBenefici() => CalcularPreuTotal() - CalcularCostTotal();

    }
}
