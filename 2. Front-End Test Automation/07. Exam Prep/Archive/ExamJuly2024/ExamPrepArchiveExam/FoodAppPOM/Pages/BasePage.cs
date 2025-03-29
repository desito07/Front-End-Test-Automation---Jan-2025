using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodAppPOM.Pages
{
    public class BasePage
    {
        protected IWebDriver driver;
        protected WebDriverWait wait;

        protected static readonly string BaseUrl = "http://softuni-qa-loadbalancer-2137572849.eu-north-1.elb.amazonaws.com:85";

        public BasePage(IWebDriver driver)
        {
            this.driver = driver;

            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }

        public IWebElement navBarFoody => driver.FindElement(By.XPath("//a[@class='navbar-brand']"));

        public IWebElement signUpButton => driver.FindElement(By.XPath("//a[@href='/User/Register']"));

        public IWebElement logInButton => driver.FindElement(By.XPath("//a[@href='/User/Login']"));

        public IWebElement learnMoreButton => driver.FindElement(By.XPath("//a[@class='btn btn-primary btn-xl rounded-pill mt-5']"));
    }
}
