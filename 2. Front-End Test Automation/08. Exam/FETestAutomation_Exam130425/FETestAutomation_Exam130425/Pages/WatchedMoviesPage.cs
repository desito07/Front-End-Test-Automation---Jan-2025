using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FETestAutomation_Exam130425.Pages
{
    public class WatchedMoviesPage : BasePage
    {
        public WatchedMoviesPage(IWebDriver driver) : base(driver)
        {

        }

        public string Url = BaseUrl + "/Catalog/Watched#watched";

        public ReadOnlyCollection<IWebElement> WatchedMoviesList => driver.FindElements(By.XPath("//div[@class='container marketing justify-content-center mb-5']"));

        public IWebElement TitleLastMovie => WatchedMoviesList.Last().FindElement(By.XPath("(//div[@class='col-lg-4']//h2)[last()]"));

        public IWebElement MarkAsUnwatchedButtonLastMovie => WatchedMoviesList.Last().FindElement(By.XPath("(//a[contains(@href,'/Movie/RemoveFromWatched')])[last()]"));

        public void OpenPage()
        {
            driver.Navigate().GoToUrl(Url);
        }
    }
}
