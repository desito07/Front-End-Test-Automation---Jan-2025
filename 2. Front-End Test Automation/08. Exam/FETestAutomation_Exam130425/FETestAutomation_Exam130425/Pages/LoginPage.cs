using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FETestAutomation_Exam130425.Pages
{
    public class LoginPage : BasePage
    {
        public LoginPage(IWebDriver driver) : base(driver)
        {

        }

        public string Url = BaseUrl + "/User/Login";

        public IWebElement EmailField => driver.FindElement(By.XPath("//input[@name='Email']"));

        public IWebElement PasswordField => driver.FindElement(By.XPath("//input[@name='Password']"));

        public IWebElement LoginButton => driver.FindElement(By.XPath("//button[@class='btn warning']"));

        public void Login(string email, string password)
        {
            ScrollToElement(EmailField);
            wait.Until(ExpectedConditions.ElementToBeClickable(EmailField));
            EmailField.SendKeys(email);

            ScrollToElement(PasswordField);
            wait.Until(ExpectedConditions.ElementToBeClickable(PasswordField));
            PasswordField.SendKeys(password);

            ScrollToElement(LoginButton);
            wait.Until(ExpectedConditions.ElementToBeClickable(LoginButton));
            LoginButton.Click();
        }
        public void OpenPage()
        {
            driver.Navigate().GoToUrl(Url);
        }
    }
}
