using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TutoFinder.Pages
{
    public class HomePage
    {
        public IWebDriver WebDriver { get; }
        public HomePage(IWebDriver webDriver)
        {
            WebDriver = webDriver;

        }
        
        public IWebElement btnBuscar => WebDriver.FindElement(By.CssSelector(".btn-search-docente"));
        public IWebElement inputSearch => WebDriver.FindElement(By.CssSelector(".search-section__input-docente"));
        public IWebElement txtSearchResult => WebDriver.FindElement(By.CssSelector(".search-section__search-results .item__nombre-docente"));
        public IWebElement itemResult => WebDriver.FindElement(By.CssSelector(".search-section__search-results .item-result"));

        public IWebElement panelDocenteInfoText => WebDriver.FindElement(By.CssSelector(".section-docente-info"));




        public IWebElement btnMisClases => WebDriver.FindElement(By.CssSelector(".main-menu__btn-misclases"));

        public IWebElement btnPerfil => WebDriver.FindElement(By.CssSelector(".main-menu__btn-perfil"));

        public void ClickBtnMisClases() => btnMisClases.Click();
        public void ClickBtnPerfil() => btnPerfil.Click();





        public void ClickBtnBuscar() { btnBuscar.Click(); }
        public void SendSearchText(string text) { inputSearch.SendKeys(text); }

        public void ClickSearchResult() { itemResult.Click(); }

        public bool DocenteInfoExist() { return panelDocenteInfoText.Displayed;  }
        
    }
}
