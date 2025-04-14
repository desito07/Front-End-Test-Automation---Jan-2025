using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodAppPOM.Pages
{
    internal class MyFoodPage : BasePage
    {
        public MyFoodPage(IWebDriver driver) : base(driver)
        {

        }

        public string Url = BaseUrl + "/";

        public ReadOnlyCollection<IWebElement> FoodCards => driver.FindElements(By.XPath("//div[@class='row gx-5 align-items-center']"));

        public IWebElement TitleLastFood => FoodCards.Last().FindElement(By.XPath(".//h2[@class='display-4']"));

        public IWebElement EditButtonLastFood => FoodCards.Last().FindElement(By.XPath(".//a[contains(@href,'/Food/Edit')]"));

        public IWebElement DeleteButtonLastFood => FoodCards.Last().FindElement(By.XPath(".//a[contains(@href,'/Food/Delete')]"));

        public IWebElement searchField => driver.FindElement(By.XPath("//input[@class='form-control rounded mt-5 xl']"));

        public IWebElement searchButton => driver.FindElement(By.XPath("//button[@class='btn btn-primary rounded-pill mt-5 col-2']"));

        public IWebElement noFoodMessage => driver.FindElement(By.XPath("//h2[@class='display-4']"));

        public void OpenPage()
        {
            driver.Navigate().GoToUrl(Url);
        }
    }
}
