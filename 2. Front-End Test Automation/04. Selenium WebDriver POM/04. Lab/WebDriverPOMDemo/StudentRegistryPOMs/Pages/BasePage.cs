using OpenQA.Selenium;
using System.Net;

namespace StudentRegistryPOM.Pages
{
   public class BasePage
    {
        protected readonly IWebDriver driver;

        public virtual string PageUrl { get; }

        public BasePage(IWebDriver driver)
        {
            this.driver = driver;
            this.driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
        }

        public IWebElement HomeLinkElement => driver.FindElement(By.XPath("//a[text()='Home']"));

        public IWebElement ViewStudentsLinkElement => driver.FindElement(By.XPath("//a[text()='View Students']"));

        public IWebElement AddtudentLinkElement => driver.FindElement(By.XPath("//a[text()='Add Student']"));

        public IWebElement PageHeading => driver.FindElement(By.XPath("//h1"));

        public void OpenPage()
        {
            driver.Navigate().GoToUrl(PageUrl);
        }

        public bool IsOpen()
        {
            return driver.Url == this.PageUrl;
        }

        public string GetPageTitle()
        {
            return driver.Title;
        }

        public string GetPageHeading()
        {
            return PageHeading.Text;
        }
    }
}

