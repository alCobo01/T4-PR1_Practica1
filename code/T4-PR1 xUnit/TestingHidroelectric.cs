using System.Reflection.Emit;
using T4PR1;

namespace T4_PR1_xUnit
{
    public class TestingHidroelectric
    {
        [Fact]
        public void TestGenEnergiaUn()
        {
            const double _cabal = 0;
            const float _rati = 6.7f;
            const float _cost = 3.4f;
            const float _preu = 7.9f;

            // Arrange
            SistemaHidroelectric sistemaHidroelectric;

            // Assert
            Assert.Throws<ArgumentException>(() => sistemaHidroelectric = new SistemaHidroelectric(DateTime.Now, _cabal, _rati, _cost, _preu));
        }

        [Fact]
        public void TestGenEnergiaDos()
        {
            const double _cabal = 26;
            const float _rati = 24.5f;
            const float _cost = 4.3f;
            const float _preu = 9.8f;

            // Arrange
            SistemaHidroelectric sistemaHidroelectric = new SistemaHidroelectric(DateTime.Now, _cabal, _rati, _cost, _preu);
            double resultatEsperat = Math.Round(_cabal * 9.8 * _rati, 3);

            // Act
            double resultatObtingut = sistemaHidroelectric.CalcularEnergiaGenerada();

            // Assert
            Assert.Equal(resultatEsperat, resultatObtingut);
        }
    }
}
