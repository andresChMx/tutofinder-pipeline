using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using TechTalk.SpecFlow;
using TutoFinder.Pages;

namespace TutoFinder.Steps
{
    [Binding]
    public class FiltrarDocentesSteps
    {
        LoginPage loginPage = null;
        HomePage homePage = null;
        MisClasesPage misClasesPage = null;
        [Given(@"el padre ha iniciado sesión en la plataforma web")]
        public void GivenElPadreHaIniciadoSesionEnLaPlataformaWeb()
        {
            IWebDriver webDriver = new ChromeDriver();
            webDriver.Navigate().GoToUrl("http://localhost:44392/identity/");

            loginPage = new LoginPage(webDriver);
            homePage = new HomePage(webDriver);

            loginPage.ClickLogin();
            loginPage.Login("alex123@gmail.com","12345");
            loginPage.ClickSubmitBtn();
        }
        
        [Given(@"el usuario padre se encuentra en la sección “Mis clases”")]
        public void GivenElUsuarioPadreSeEncuentraEnLaSeccionMisClases()
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
        
        [When(@"seleccione la opción “Buscar” y redacte el nombre de un docente")]
        public void WhenSeleccioneLaOpcionBuscarYRedacteElNombreDeUnDocente()
        {
            homePage.ClickBtnBuscar();
            homePage.SendSearchText("Jose Luis");


        }
        
        [When(@"ingrese el nombre del curso en el formulario de búsqueda y presione en buscar")]
        public void WhenIngreseElNombreDelCursoEnElFormularioDeBusquedaYPresioneEnBuscar()
        {
            misClasesPage.SendCursoText("Algebra");
            misClasesPage.ClickButtonSearch();

        }
        
        [When(@"ingrese el rango de un costo deseado en el formulario de búsqueda y seleccione la opción “Buscar”")]
        public void WhenIngreseElRangoDeUnCostoDeseadoEnElFormularioDeBusquedaYSeleccioneLaOpcionBuscar()
        {
            misClasesPage.SendCostoText("50","100");
            misClasesPage.ClickButtonSearch();
        }
        
        [When(@"ingrese una cantidad de horas en el formulario de búsqueda y seleccione “Buscar”")]
        public void WhenIngreseUnaCantidadDeHorasEnElFormularioDeBusquedaYSeleccioneBuscar()
        {
            misClasesPage.SendHorasText("4");
            misClasesPage.ClickButtonSearch();
        }
        
        [Then(@"se mostrara el docente solicitado, donde al seleccionarlo se mostrara una interfaz con sus detalles")]
        public void ThenSeMostraraElDocenteSolicitadoDondeAlSeleccionarloSeMostraraUnaInterfazConSusDetalles()
        {
            homePage.ClickSearchResult();
            Assert.IsTrue(homePage.DocenteInfoExist());
        }
        
        [Then(@"se listaran los docentes que enseñen el curso ingresado")]
        public void ThenSeListaranLosDocentesQueEnsenenElCursoIngresado()
        {
            Assert.IsTrue(misClasesPage.EvalSearchResultByCurso("Algebra"));
        }
        
        [Then(@"se listaran solo los docentes que cobren esa cantidad")]
        public void ThenSeListaranSoloLosDocentesQueCobrenEsaCantidad()
        {
            Assert.IsTrue(misClasesPage.EvalSearchResultByCosto(50,100));
        }
        
        [Then(@"se mostraran los docentes que estén enseñando la cantidad de horas deseadas")]
        public void ThenSeMostraranLosDocentesQueEstenEnsenandoLaCantidadDeHorasDeseadas()
        {
            Assert.IsTrue(misClasesPage.EvalSearchResultByTiempo("4"));
        }
    }
}
