using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;
using System;
using System.Reflection.Emit;

namespace T4PR1
{
    public class Simulacio
    {
        public TipusSistema? Tipus { get; set; }
        public DateTime Data { get; set; }
        public double Dada { get; set; }
        public double Rati { get; set; }
        public double Cost { get; set; }
        public double Preu { get; set; }
        public double EnergiaGenerada { get; set; }
        public double CostTotal { get; set; }
        public double PreuTotal { get; set; }
        public double Benefici { get; set; }
    }
}
