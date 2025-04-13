using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FETestAutomation_Exam130425.Pages
{
    public class AllMoviesPage : BasePage
    {
        public AllMoviesPage(IWebDriver driver) : base(driver)
        {

        }

        public string Url = BaseUrl + "/Catalog/All#all";

        public ReadOnlyCollection<IWebElement> AllMoviesList => driver.FindElements(By.XPath("//div[@class='container marketing justify-content-center mb-5']"));

        public IWebElement TitleLastMovie => AllMoviesList.Last().FindElement(By.XPath("(//div[@class='col-lg-4']//h2)[last()]"));

        public IWebElement DescriptionLastMovie => AllMoviesList.Last().FindElement(By.XPath("(//div[@class='col-lg-4']//p)[last()]"));

        public IWebElement EditeButtonLastMovie => AllMoviesList.Last().FindElement(By.XPath("(//a[contains(@href,'/Movie/Edit')])[last()]"));

        public IWebElement DeleteButtonLastMovie => AllMoviesList.Last().FindElement(By.XPath("(//a[contains(@href,'/Movie/Delete')])[last()]"));

        public IWebElement MarkAsWatchedButtonLastMovie => AllMoviesList.Last().FindElement(By.XPath("(//a[contains(@href,'/Movie/MarksAsWatched')])[last()]"));

        public void OpenPage()
        {
            driver.Navigate().GoToUrl(Url);
        }

        public void ScrollAndClickDeleteButton()
        {
            wait.Until(ExpectedConditions.ElementToBeClickable(DeleteButtonLastMovie));

            ScrollToElement(DeleteButtonLastMovie);

            DeleteButtonLastMovie.Click();
        }

        public void ScrollAndClickEditButton()
        {
            wait.Until(ExpectedConditions.ElementToBeClickable(EditeButtonLastMovie));

            ScrollToElement(EditeButtonLastMovie);

            EditeButtonLastMovie.Click();
        }

        public void ScrollToElement(IWebElement element)
        {
            var jsExecutor = (IJavaScriptExecutor)driver;
            jsExecutor.ExecuteScript("arguments[0].scrollIntoView({behavior: 'smooth', block: 'center'});", element);

            System.Threading.Thread.Sleep(500);
        }


    }
}
