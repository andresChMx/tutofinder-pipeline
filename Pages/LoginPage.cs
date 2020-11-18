using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TutoFinder.Pages
{
    
    public class LoginPage
    {
        public IWebDriver WebDriver { get; }
        public LoginPage(IWebDriver webDriver) {
            WebDriver=webDriver;

        }
        public IWebElement lnkLogin => WebDriver.FindElement(By.CssSelector(".auth-form__btn-login"));
        public IWebElement txtEmail => WebDriver.FindElement(By.CssSelector(".auth-form__input-email"));
        public IWebElement txtPassword => WebDriver.FindElement(By.CssSelector(".auth-form__input-password"));
        public IWebElement btnLogin => WebDriver.FindElement(By.CssSelector(".auth-form__btn-submit-login"));



        public void ClickLogin() {
            lnkLogin.Click();
        }
        public void Login(string email, string password) {
            txtEmail.SendKeys(email);
            txtPassword.SendKeys(password);
        }
        public void ClickSubmitBtn() => btnLogin.Click();


    }
}
