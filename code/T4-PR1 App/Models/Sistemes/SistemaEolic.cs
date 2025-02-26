using System;

namespace T4PR1
{
    public class SistemaEolic : SistemaEnergia, ICalculEnergia
    {
        private const string _name = "Eòlica";
        private const int _minim = 5;
        private const int _velocitatDefecte = 10;

        private double _velocitatVent;

        //Propietats
        public double VelocitatVent
        {
            get { return _velocitatVent; }
            set
            {
                if (!(value >= _minim)) throw new ArgumentException(Missatges.EolicArgumentException);
                _velocitatVent = value;
            }
        }

        //Constuctor amb major càrrega lògica
        public SistemaEolic(DateTime data, double velocitatVent, float rati, float cost, float preu)
        {
            Data = data;
            Tipus = _name;
            VelocitatVent = velocitatVent;
            Rati = rati;
            Cost = cost;
            Preu = preu;
        }

        //Constructor amb menor càrrega lògica
        public SistemaEolic()
        {
            Data = DateTime.Now;
            Tipus = _name;
            VelocitatVent = _velocitatDefecte;
        }

        //Mètodes de la classe
        /// <summary>
        /// Calcula l'energia generada pel sistema eòlic.
        /// </summary>
        /// <returns>Retorna l'energia generada en kWh.</returns>
        public override double CalculEnergia() => Math.Pow(VelocitatVent, 3) * 0.2;

        /// <summary>
        /// Retorna una representació en cadena del sistema eòlic.
        /// </summary>
        /// <returns>Una cadena que representa el sistema eòlic amb la data, la velocitat del vent i l'energia calculada.</returns>
        public override string ToString() => $"Sistema Eòlic: {Data} - Velocitat del vent: {VelocitatVent} m/s - Energia Calculada: {CalculEnergia()} kWh";
    }
}