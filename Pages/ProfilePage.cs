using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TutoFinder.Pages
{
    public class ProfilePage
    {
        public IWebDriver WebDriver { get; }
        public ProfilePage(IWebDriver webDriver)
        {
            WebDriver = webDriver;

        }
        public IWebElement btnTarjetas => WebDriver.FindElement(By.CssSelector(".btn-show-tarjetas"));

        public IWebElement btnEliminarTarjeta => WebDriver.FindElement(By.CssSelector(".btn-delete-tarjeta"));
        public IWebElement btnConfirmDeletionTarjetas => WebDriver.FindElement(By.CssSelector(".btn-confirm-deletion-tarjeta"));

        public IWebElement btnAddTarjeta => WebDriver.FindElement(By.CssSelector(".btn-add-tarjeta"));

        public IWebElement textNumeroTarjeta => WebDriver.FindElement(By.CssSelector(".form-registro-tarjeta__input-numero"));

        public IWebElement textfechaVencimiento => WebDriver.FindElement(By.CssSelector(".form-registro-tarjeta__input-fecha"));
        public IWebElement btnSubmitRegistry => WebDriver.FindElement(By.CssSelector(".form-registro-tarjeta__btn-submit"));

        public IWebElement textConfirmationMessage => WebDriver.FindElement(By.CssSelector(".box-result-message"));

        public void ClickBtnTarjetas() => btnTarjetas.Click();

        public void ClickBtnDeleteTarjeta() => btnEliminarTarjeta.Click();

        public void ClickBtnConfirmDeletion() => btnConfirmDeletionTarjetas.Click();



        public void ClickBtnAddTarjeta() => btnAddTarjeta.Click();

        public void RegisterTarjeta(string numero, string fecha)
        {
            textNumeroTarjeta.SendKeys(numero);
            textfechaVencimiento.SendKeys(fecha);
        }

        public void ClickBtnSubmit() => btnSubmitRegistry.Click();

        public bool TarjetaRegistrySuccess()
        {
            if (textConfirmationMessage.Text == "Los datos ingresados no son correctos")
            {
                return false;
            }else if (textConfirmationMessage.Text == "La tarjeta fue registrada exitooramente")
            {
                return true;
            }
            return false;
        }

    }
}
