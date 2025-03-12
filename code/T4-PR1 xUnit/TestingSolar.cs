using T4PR1;

namespace T4_PR1_xUnit
{
    public class TestingSolar
    {
        [Fact]
        public void TestGenEnergiaUn()
        {
            const double _horesSol = 0;
            const float _rati = 6.7f;
            const float _cost = 3.4f;
            const float _preu = 7.9f;

            // Arrange
            SistemaSolar sistemaSolar;

            // Assert
            Assert.Throws<ArgumentException>(() => sistemaSolar = new SistemaSolar(DateTime.Now, _horesSol, _rati, _cost, _preu));
        }

        [Fact]
        public void TestGenEnergiaDos()
        {
            const double _horesSol = 3;
            const float _rati = 4;
            const float _cost = 2.3f;
            const float _preu = 20;

            // Arrange
            SistemaSolar sistemaSolar = new SistemaSolar(DateTime.Now, _horesSol, _rati, _cost, _preu);
            double resultatEsperat = _horesSol * _rati;

            // Act
            double resultatObtingut = sistemaSolar.CalcularEnergiaGenerada();

            // Assert
            Assert.Equal(resultatEsperat, resultatObtingut);
        }

    }
}
