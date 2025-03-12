using T4PR1;

namespace T4_PR1_xUnit
{
    public class TestingEolic
    {
        [Fact]
        public void TestGenEnergiaUn()
        {
            const double _velocitatVent = 2.5;
            const float _rati = 35f;
            const float _cost = 2.56f;
            const float _preu = 4.2f;

            // Arrange
            SistemaEolic sistemaEolic;

            // Assert
            Assert.Throws<ArgumentException>(() => sistemaEolic = new SistemaEolic(DateTime.Now, _velocitatVent, _rati, _cost, _preu));
        }

        [Fact]
        public void TestGenEnergiaDos()
        {
            const double _velocitatVent = 12.2;
            const float _rati = 3.5f;
            const float _cost = 12.4f;
            const float _preu = 15.6f;

            // Arrange
            SistemaEolic sistemaEolic = new SistemaEolic(DateTime.Now, _velocitatVent, _rati, _cost, _preu);
            double resultatEsperat = Math.Pow(_velocitatVent, 3) * _rati;

            // Act
            double resultatObtingut = sistemaEolic.CalcularEnergiaGenerada();

            // Assert
            Assert.Equal(resultatEsperat, resultatObtingut);
        }

        [Fact]
        public void TestCalcularCostUn()
        {
            const double _velocitatVent = 24.2;
            const float _rati = 32.3f;
            const float _cost = 11.2f;
            const float _preu = 13.6f;

            // Arrange
            SistemaEolic sistemaEolic = new SistemaEolic(DateTime.Now, _velocitatVent, _rati, _cost, _preu);
            double costTotalEsperat = Math.Round((Math.Pow(_velocitatVent, 3) * _rati * _cost), 2);

            // Act
            double costTotalObtingut = sistemaEolic.CalcularCostTotal();

            // Assert
            Assert.Equal(costTotalEsperat, costTotalObtingut);
        }

        [Fact]
        public void TestCalcularCostDos()
        {
            const double _velocitatVent = 10;
            const float _rati = 1.23f;
            const float _cost = 5f;
            const float _preu = 10f;

            // Arrange
            SistemaEolic sistemaEolic = new SistemaEolic(DateTime.Now, _velocitatVent, _rati, _cost, _preu);
            double costTotalEsperat = Math.Round((Math.Pow(_velocitatVent, 3) * _rati * _cost), 2);

            // Act
            double costTotalObtingut = sistemaEolic.CalcularCostTotal();

            // Assert
            Assert.Equal(costTotalEsperat, costTotalObtingut);
        }

        [Fact]
        public void TestCalcularBeneficiUn()
        {
            const double _velocitatVent = 45.2;
            const float _rati = 21.2f;
            const float _cost = 10;
            const float _preu = 11;

            // Arrange
            SistemaEolic sistemaEolic = new SistemaEolic(DateTime.Now, _velocitatVent, _rati, _cost, _preu);
            double beneficiEsperat = Math.Round((Math.Pow(_velocitatVent, 3) * _rati * (_preu - _cost)), 2);

            // Act
            double beneficiObtingut = sistemaEolic.CalcularBenefici();

            // Assert
            Assert.Equal(beneficiEsperat, beneficiObtingut);
        }

        [Fact]
        public void TestCalcularBeneficiDos()
        {
            const double _velocitatVent = 15.2;
            const float _rati = 1.43f;
            const float _cost = 5;
            const float _preu = 13;

            // Arrange
            SistemaEolic sistemaEolic = new SistemaEolic(DateTime.Now, _velocitatVent, _rati, _cost, _preu);
            double beneficiEsperat = Math.Round((Math.Pow(_velocitatVent, 3) * _rati * (_preu - _cost)), 2);

            // Act
            double beneficiObtingut = sistemaEolic.CalcularBenefici();

            // Assert
            Assert.Equal(beneficiEsperat, beneficiObtingut);
        }
    }
}
