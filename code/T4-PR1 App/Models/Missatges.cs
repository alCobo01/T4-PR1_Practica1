using System;

namespace T4PR1
{
    public static class Missatges
    {
        public const string OpcioUnMenuMissatge = "\n Iniciant la simulació... que comenci la màgia energètica!\n Quantes simulacions vols fer? ",
            OpcioDosValidMenuMissatge = "Aquí tens les teves simulacions. Atenció, podries acabar creant una nova central elèctrica! ",
            OpcioDosInvalidMenuMissatge = "Ah, vols veure el futur? Doncs encara no tenim ni una sol dada. Fes la primera simulació i comencem!\n",
            OpcioTresMenuMissatge = "Fins aviat! Torna quan vulguis il·luminar el teu dia amb simulacions",
            OpcioEquivocadaMenuMissatge = "Error: si us plau, introdueix un número vàlid.",
            MissatgeErrorTryParse = "Error: si us plau, introdueix un número vàlid: ",
            MissatgeErrorTryParseAmbRang = "Error: si us plau, introdueix un número vàlid entre {0} i {1}: ",
            EolicArgumentException = "La velocitat del vent ha de ser superior a 5 m/s! ",
            HidroelectricArgumentException = "El cabal ha de ser major a 20 m^3! ",
            SolarArgumentException = "Les hores de sol han de ser superiors a 1! ",
            FinalSimulacions = "Simulacions finalitzades amb èxit! \n",
            SimulacioAcabada = "Aquesta simulació té una energia total de {0} kWh \n";    
    }
}
