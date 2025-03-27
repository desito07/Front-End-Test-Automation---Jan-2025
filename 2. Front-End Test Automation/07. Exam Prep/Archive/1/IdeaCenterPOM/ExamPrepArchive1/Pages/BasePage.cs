using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;


namespace ExamPrepArchive1.Pages
{
    public class BasePage
    {
        protected IWebDriver driver;
        protected WebDriverWait wait;

        protected static readonly string BaseUrl = "http://softuni-qa-loadbalancer-2137572849.eu-north-1.elb.amazonaws.com:83";

        public BasePage(IWebDriver driver)
        {
            this.driver = driver;

            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }

        public IWebElement Homelink => driver.FindElement(By.XPath("//img[@class='rounded-circle']"));
        public IWebElement MyProfileLink => driver.FindElement(By.XPath("//li[@class='nav-item']//a[@href='/Profile']]"));

        public IWebElement MyIdeasLink => driver.FindElement(By.XPath("//li[@class='nav-item']//a[@href='/Ideas/MyIdeas']]"));

        public IWebElement CreateIdeaLink => driver.FindElement(By.XPath("//li[@class='nav-item']//a[@href='/Ideas/Create']"));

        public IWebElement LogoutButton => driver.FindElement(By.XPath("//a[@class='btn btn-primary me-3']"));

        public IWebElement LoginButton => driver.FindElement(By.XPath("//a[@class='btn btn-outline-info px-3 me-2']"));
    }
}
