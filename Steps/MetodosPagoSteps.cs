using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using TechTalk.SpecFlow;
using TutoFinder.Pages;

namespace TutoFinder.Steps
{
    [Binding]
    public class MetodosPagoSteps
    {
        LoginPage loginPage = null;
        HomePage homePage = null;
        ProfilePage profilePage = null;
        [Given(@"el usuario padre ha iniciado sesión correctamente")]
        public void GivenElUsuarioPadreHaIniciadoSesionCorrectamente()
        {
            IWebDriver webDriver = new ChromeDriver();
            webDriver.Navigate().GoToUrl("http://localhost:44392/identity/");

            loginPage = new LoginPage(webDriver);
            homePage = new HomePage(webDriver);
            profilePage = new ProfilePage(webDriver);

            loginPage.ClickLogin();
            loginPage.Login("alex123@gmail.com", "12345");
            loginPage.ClickSubmitBtn();
        }

        [Given(@"se encuentra en la sección Tarjetas de la vista Perfil")]
        public void GivenSeEncuentraEnLaSeccionTarjetasDeLaVistaPerfil()
        {
            homePage.ClickBtnPerfil();
            profilePage.ClickBtnTarjetas();
        }

        [When(@"seleccione la opción “Agregar tarjeta”")]
        public void WhenSeleccioneLaOpcionAgregarTarjeta()
        {
            profilePage.ClickBtnAddTarjeta();
        }

        [Then(@"se mostrara un formulario para el registro de una nueva tarjeta")]
        public void ThenSeMostraraUnFormularioParaElRegistroDeUnaNuevaTarjeta()
        {
            profilePage.RegisterTarjeta("123123123","12/12");
            profilePage.ClickBtnSubmit();
        }

        [Given(@"el ususario padre se encuentra en el formulario de registro de nueva tarjeta")]
        public void GivenElUsusarioPadreSeEncuentraEnElFormularioDeRegistroDeNuevaTarjeta()
        {
            IWebDriver webDriver = new ChromeDriver();
            webDriver.Navigate().GoToUrl("http://localhost:44392/identity/");

            loginPage = new LoginPage(webDriver);
            homePage = new HomePage(webDriver);
            profilePage = new ProfilePage(webDriver);

            loginPage.ClickLogin();
            loginPage.Login("alex123@gmail.com", "12345");
            loginPage.ClickSubmitBtn();

            homePage.ClickBtnPerfil();
            profilePage.ClickBtnTarjetas();
            profilePage.ClickBtnAddTarjeta();
        }

        [When(@"se ingrese información incorrecta y se envié el formulario")]
        public void WhenSeIngreseInformacionIncorrectaYSeEnvieElFormulario()
        {
            profilePage.RegisterTarjeta("asdasdasdads", "12/12");
            profilePage.ClickBtnSubmit();
        }

        [Then(@"el sistema mostrara el mensaje “los datos no son correctos”")]
        public void ThenElSistemaMostraraElMensajeLosDatosNoSonCorrectos()
        {
            Assert.IsFalse(profilePage.TarjetaRegistrySuccess());
        }

        [When(@"seleccione la opción “eliminar” de una tarjeta registrada")]
        public void WhenSeleccioneLaOpcionEliminarDeUnaTarjetaRegistrada()
        {
            profilePage.ClickBtnDeleteTarjeta();
        }

        [Then(@"se mostrara una ventana de confirmación para esa accion\.")]
        public void ThenSeMostraraUnaVentanaDeConfirmacionParaEsaAccion_()
        {
            profilePage.ClickBtnConfirmDeletion();
        }


    }
}
