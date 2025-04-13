using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FETestAutomation_Exam130425.Pages
{
    public class AddMoviePage : BasePage
    {
        public AddMoviePage(IWebDriver driver) : base(driver)
        {

        }

        public string Url = BaseUrl + "/Catalog/Add";

        public IWebElement MovieTitle => driver.FindElement(By.XPath("//input[@name='Title']"));
        public IWebElement MovieDescription => driver.FindElement(By.XPath("//textarea[@name='Description']"));

        public IWebElement MovieUrl => driver.FindElement(By.XPath("//input[@name='PosterUrl']"));

        public IWebElement YoutubeLink => driver.FindElement(By.XPath("//input[@name='TrailerLink']"));

        public IWebElement MarkedAsWatched => driver.FindElement(By.XPath("//div[@class='form-check form-outline mb-4']"));

        public IWebElement AddButton => driver.FindElement(By.XPath("//button[@class='btn warning']"));

        public IWebElement CancelButton => driver.FindElement(By.XPath("//a[@class='btn btn-danger']"));

        public IWebElement TitleErrorMessage => driver.FindElement(By.XPath("//div[@class='toast-message']"));

        public IWebElement DescriptionErrorMessage => driver.FindElement(By.XPath("//div[@class='toast-message']"));

        

        public void AddMovie(string title, string description)
        {
            MovieTitle.SendKeys(title);
            MovieDescription.SendKeys(description);
            

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementToBeClickable(AddButton));
            AddButton.Click();
        }

        public void AssertTitleErrorMessages()
        {
            Assert.True(TitleErrorMessage.Text.Equals("The Title field is required."), "Title message is not as expected");
        }

        public void AssertDescriptionErrorMessages()
        {
            Assert.True(DescriptionErrorMessage.Text.Equals("The Description field is required."), "Decription field is not as expected");
        }

        public void OpenPage()
        {
            driver.Navigate().GoToUrl(Url);
        }
    }
}
