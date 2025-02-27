using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;
using System;
using System.Reflection.Emit;

namespace T4PR1
{
    public class Simulacio
    {
        public List<SistemaEnergia> simulacions = new List<SistemaEnergia>();

        /// <summary>
        /// Crea un nou sistema d'energia basat en l'opció seleccionada.
        /// </summary>
        /// <param name="opcio">L'opció seleccionada per l'usuari (1: Hidroelèctrica, 2: Eòlica, 3: Solar).</param>
        /// <param name="dada">La dada específica del sistema seleccionat (cabal, velocitat del vent, hores de sol).</param>
        /// <param name="rati">El rati de conversió de l'energia generada pel sistema.</param>
        /// <param name="cost">El cost de creació del sistema.</param>
        /// <param name="preu">El preu de venda de l'energia generada pel sistema.</param>
        /// <returns>Un objecte de tipus SistemaEnergia corresponent a l'opció seleccionada.</returns>
        //public void CrearSimulacio(int opcio, float dada, float rati, float cost, float preu)
        //{
        //    switch (opcio)
        //    {
        //        case 1:
        //            simulacions.Add(new SistemaHidroelectric(DateTime.Now, dada, rati, cost, preu));
        //            break;
        //        case 2:
        //            simulacions.Add(new SistemaEolic(DateTime.Now, dada, rati, cost, preu));
        //            break;
        //        case 3:
        //            simulacions.Add(new SistemaSolar(DateTime.Now, dada, rati, cost, preu));
        //            break;
        //        default:
        //            throw new ArgumentException(Missatges.OpcioEquivocadaMenuMissatge);
        //    }
        //}
    }
}
