using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodAppPOM.Pages
{
    internal class LoginPage : BasePage
    {
        public LoginPage(IWebDriver driver) : base(driver)
        {

        }

        public string Url = BaseUrl + "/User/Login";

        public IWebElement UsernameField => driver.FindElement(By.XPath("//input[@id='username']"));

        public IWebElement PasswordField => driver.FindElement(By.XPath("//input[@id='password']"));

        public IWebElement LoginButton => driver.FindElement(By.XPath("//button[@class='btn btn-primary btn-block fa-lg gradient-custom-2 mb-3']"));

        public void Login(string username, string password)
        {
            UsernameField.SendKeys(username);
            PasswordField.SendKeys(password);
            LoginButton.Click();
        }

        public void OpenPage()
        {
            driver.Navigate().GoToUrl(Url);
        }
    }
}
