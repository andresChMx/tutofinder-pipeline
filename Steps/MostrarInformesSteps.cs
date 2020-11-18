using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using TechTalk.SpecFlow;
using TutoFinder.Pages;

namespace TutoFinder.Steps
{
    [Binding]
    public class MostrarInformesSteps
    {
        LoginPage loginPage = null;
        HomePage homePage = null;
        MisClasesPage misClasesPage = null;
        [Given(@"el padre de familia se encuentra en la sección “Mis clases”")]
        public void GivenElPadreDeFamiliaSeEncuentraEnLaSeccionMisClases()
        {
            IWebDriver webDriver = new ChromeDriver();
            webDriver.Navigate().GoToUrl("http://localhost:44392/identity/");

            loginPage = new LoginPage(webDriver);
            homePage = new HomePage(webDriver);
            misClasesPage = new MisClasesPage(webDriver);

            loginPage.ClickLogin();
            loginPage.Login("alex123@gmail.com", "12345");
            loginPage.ClickSubmitBtn();

            homePage.ClickBtnMisClases();
        }

        [When(@"se dirija a los detalles de una clase y no hay informacion")]
        public void WhenSeDirijaALosDetallesDeUnaClaseYNoHayInformacion()
        {
            misClasesPage.ClickBtnDetallesClase();
        }

        [Then(@"no podra descargar el informe del alumno y se mostrara el mensaje “informe no disponible”")]
        public void ThenNoPodraDescargarElInformeDelAlumnoYSeMostraraElMensajeInformeNoDisponible()
        {
            Assert.IsFalse(misClasesPage.InformeDisponible());
        }

        [When(@"se dirija a los detalles de la clase y el informe ha sido subido")]
        public void WhenSeDirijaALosDetallesDeLaClaseYElInformeHaSidoSubido()
        {
            misClasesPage.ClickBtnDetallesClase();
        }

        [Then(@"podra visualizar el nombre del informe y al lado un botón para descargarlo")]
        public void ThenPodraVisualizarElNombreDelInformeYAlLadoUnBotonParaDescargarlo()
        {
            Assert.IsTrue(misClasesPage.InformeDisponible());
        }

        [Given(@"el informe ya está disponible")]
        public void GivenElInformeYaEstaDisponible()
        {
            IWebDriver webDriver = new ChromeDriver();
            webDriver.Navigate().GoToUrl("http://localhost:44392/identity/");

            loginPage = new LoginPage(webDriver);
            homePage = new HomePage(webDriver);
            misClasesPage = new MisClasesPage(webDriver);

            loginPage.ClickLogin();
            loginPage.Login("alex123@gmail.com", "12345");
            loginPage.ClickSubmitBtn();

            homePage.ClickBtnMisClases();
            misClasesPage.ClickBtnDetallesClase();
            Assert.IsTrue(misClasesPage.InformeDisponible());
        }

        [When(@"el padre determine que el archivo no cumple con lo esperado y seleccione la opción notificar docente")]
        public void WhenElPadreDetermineQueElArchivoNoCumpleConLoEsperadoYSeleccioneLaOpcionNotificarDocente()
        {
            misClasesPage.ClickBtnNotificarCorrecion();
        }

        [Then(@"se enviara una notificación al docente solicitando la corrección del informe\.")]
        public void ThenSeEnviaraUnaNotificacionAlDocenteSolicitandoLaCorreccionDelInforme_()
        {
            Assert.IsTrue(misClasesPage.NotificacionEnviada());
        }

    }
}
