using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FETestAutomation_Exam130425.Pages
{
    public class BasePage
    {
        protected IWebDriver driver;
        protected WebDriverWait wait;

        protected static readonly string BaseUrl = "https://d24hkho2ozf732.cloudfront.net";

        public BasePage(IWebDriver driver)
        {
            this.driver = driver;

            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }

        public IWebElement aboutUsButton => driver.FindElement(By.XPath("//a[text()='About Us']"));

        public IWebElement ourServicesButton => driver.FindElement(By.XPath("//a[text()='Our Services']"));

        public IWebElement loginButton => driver.FindElement(By.XPath("//a[text()='Login']"));

        public IWebElement registerButton => driver.FindElement(By.XPath("//a[text()='Register']"));

        public IWebElement copyrightsButton => driver.FindElement(By.XPath("//a[text()='Copyrights']"));

        public void ScrollToElement(IWebElement element)
        {
            var jsExecutor = (IJavaScriptExecutor)driver;
            jsExecutor.ExecuteScript("arguments[0].scrollIntoView({behavior: 'smooth', block: 'center'});", element);
            System.Threading.Thread.Sleep(300);
        }
    }
}
