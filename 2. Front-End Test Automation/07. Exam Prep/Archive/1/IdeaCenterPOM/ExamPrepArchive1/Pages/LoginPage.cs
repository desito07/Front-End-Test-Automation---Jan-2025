using OpenQA.Selenium;
using OpenQA.Selenium.DevTools.V132.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamPrepArchive1.Pages
{
    public class LoginPage : BasePage
    {
        public LoginPage(IWebDriver driver) : base(driver)
        {

        }

        public string Url = BaseUrl + "/Users/Login";

        public IWebElement EmailField => driver.FindElement(By.XPath("//input[@id='typeEmailX-2']"));

        public IWebElement PasswordField => driver.FindElement(By.XPath("//input[@id='typePasswordX-2']"));

        public IWebElement SignInButton => driver.FindElement(By.XPath("//button[@class='btn btn-primary btn-lg btn-block']"));

        public void Login(string email, string password)
        {
            EmailField.SendKeys(email);
            PasswordField.SendKeys(password);
            SignInButton.Click();
        }

        public void OpenPage()
        {
            driver.Navigate().GoToUrl(Url);
        }
    }
}
