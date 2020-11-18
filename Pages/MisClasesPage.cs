using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TutoFinder.Pages
{
    public class MisClasesPage
    {
        public IWebDriver WebDriver { get; }
        public MisClasesPage(IWebDriver webDriver)
        {
            WebDriver = webDriver;

        }
        /*INFORMES*/
        public IWebElement btnVerDetallesClase => WebDriver.FindElement(By.CssSelector(".item-clase__btn-detalle"));
        public IWebElement textStatusInforme => WebDriver.FindElement(By.CssSelector(".box-message-informe"));

        public IWebElement btnNotificarCorreccion => WebDriver.FindElement(By.CssSelector(".btn-notificate"));

        public IWebElement textStatusNotification => WebDriver.FindElement(By.CssSelector(".box-message-notification"));

        public void ClickBtnDetallesClase()
        {
            btnVerDetallesClase.Click();
        }
        public bool InformeDisponible()
        {
            if (textStatusInforme.Text == "Informe no disponible") {
                return false;
            }
            else
            {
                return true;
            }
        }
        public void ClickBtnNotificarCorrecion()
        {
            btnNotificarCorreccion.Click();
        }
        public bool NotificacionEnviada()
        {
            if(textStatusNotification.Text=="Se ha notificado al docente para una correcion")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /*BUSQUEDA POR FILTRO*/
        public IWebElement inputCurso => WebDriver.FindElement(By.CssSelector(".search-form__input-curso"));
        public IWebElement inputMinCosto => WebDriver.FindElement(By.CssSelector(".search-form__input-min-costo"));
        public IWebElement inputMaxCosto => WebDriver.FindElement(By.CssSelector(".search-form__input-max-costo"));
        public IWebElement inputHoras => WebDriver.FindElement(By.CssSelector(".search-form__input-horas"));
        public IWebElement btnBuscar => WebDriver.FindElement(By.CssSelector(".search-form__btn-submit"));

        public IWebElement searchResultTxtByCurso => WebDriver.FindElement(By.CssSelector(".search-results-box__result__name"));
        public IWebElement searchResultTxtByCosto => WebDriver.FindElement(By.CssSelector(".search-results-box__result__price"));
        public IWebElement searchResultTxtByTiempo => WebDriver.FindElement(By.CssSelector(".search-results-box__result__time"));
        public void SendCursoText(string cursoName)
        {
            inputCurso.SendKeys(cursoName);
        }
        public void SendCostoText(string minCosto,string maxCosto)
        {
            inputMinCosto.SendKeys(minCosto);
            inputMaxCosto.SendKeys(maxCosto);
        }
        public void SendHorasText(string horas)
        {
            inputHoras.SendKeys(horas);
        }


        public void ClickButtonSearch() { btnBuscar.Click(); }

        public bool EvalSearchResultByCurso(string resultText)
        {
            return searchResultTxtByCurso.Text == resultText;
        }
        public bool EvalSearchResultByCosto(int minCosto,int maxCosto)
        {
            int costo = Int32.Parse(searchResultTxtByCosto.Text);
            return (costo > minCosto && costo < maxCosto);
        }
        public bool EvalSearchResultByTiempo(string resultText)
        {
            return searchResultTxtByTiempo.Text == resultText;
        }

    }
}
