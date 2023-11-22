using Entidades;
using Entidades.Modelos;

namespace TestUnitarios
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void EliminarAtleta_BuscarUnAtletaParaEliminarDeLista_RetornaraUnStringInformandoQueNoSeEncuentra()
        {
            //arrange
            BoxCrossfit boxTest = new BoxCrossfit("Chronos Test");
            Atleta atletaTest = new Atleta("Ruben", "Lopez", 34786815, new DateTime(1989, 11, 18), Atleta.EPase.Libre);
            string expected = "No se encuentra en lista.";
            string actual;

            //act
            actual = boxTest.ElimiarAtleta(atletaTest);

            //assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [ExpectedException(typeof(RegistroPagoCuotaException))]
        public void RegistroPago_AlRegistrarPagoConIgualMesYAnioDeOtroExistente_DebeRetornarExcepcion()
        {
            //arrange
            Atleta atletaTest = new Atleta("Ruben", "Lopez", 34786815, new DateTime(1989, 11, 18), Atleta.EPase.Libre);
            Cuota cuotaTest = new Cuota(Cuota.EMetodoDePago.Efectivo, 15000, Atleta.EPase.Libre, new DateTime(2023, 11, 15), 34786815);
            Cuota cuotaTest2 = new Cuota(Cuota.EMetodoDePago.Efectivo, 12000, Atleta.EPase.UnaClase, new DateTime(2023, 11, 15), 35787819);
            bool cuotaIngreso = (atletaTest + cuotaTest2);
            bool resultado;

            //act
            resultado = Atleta.RegistroPago(atletaTest, cuotaTest2);

            //assert


        }




    }
}