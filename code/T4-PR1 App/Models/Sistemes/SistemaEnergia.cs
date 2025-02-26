using System;

namespace T4PR1
{
    public abstract class SistemaEnergia
    {
        protected float Rati { get; set; }
        protected float Cost { get; set; }
        protected float Preu { get; set; }
        protected DateTime Data { get; set; }
        protected string? Tipus { get; set; }

        /// <summary>
        /// Calcula l'energia del sistema.
        /// </summary>
        /// <returns>Retorna el valor de l'energia calculada.</returns>
        public abstract double CalculEnergia();
    }
}
