using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FETestAutomation_Exam130425.Pages
{
    public class EditMoviePage : BasePage
    {
        public EditMoviePage(IWebDriver driver) : base(driver)
        {

        }

        public string Url = BaseUrl + "/Movie/Edit";

        public IWebElement TitleField => driver.FindElement(By.XPath("//input[@name='Title']"));

        public IWebElement DescriptionField => driver.FindElement(By.XPath("//textarea[@name='Description']"));

        public IWebElement MovieUrl => driver.FindElement(By.XPath("//input[@name='PosterUrl']"));

        public IWebElement YoutubeLink => driver.FindElement(By.XPath("//input[@name='TrailerLink']"));

        public IWebElement MarkedAsWatched => driver.FindElement(By.XPath("//div[@class='form-check form-outline mb-4']"));

        public IWebElement EditButton => driver.FindElement(By.XPath("//button[@class='btn warning']"));

        public IWebElement CancelButton => driver.FindElement(By.XPath("//a[@class='btn btn-danger']"));
    }
}
