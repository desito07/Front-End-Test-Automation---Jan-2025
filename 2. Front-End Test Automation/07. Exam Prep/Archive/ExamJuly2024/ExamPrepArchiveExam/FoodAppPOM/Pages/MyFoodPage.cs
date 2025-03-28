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


        public void OpenPage()
        {
            driver.Navigate().GoToUrl(Url);
        }
    }
}
