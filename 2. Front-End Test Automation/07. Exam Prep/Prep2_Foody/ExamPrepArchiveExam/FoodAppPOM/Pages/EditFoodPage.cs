using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodAppPOM.Pages
{
    public class EditFoodPage : BasePage
    {
        public EditFoodPage(IWebDriver driver) : base(driver)
        {

        }

        public string Url = BaseUrl + "/Food/Edit";

        public IWebElement FoodName => driver.FindElement(By.XPath("//input[@id='name']"));
        public IWebElement FoodDescription => driver.FindElement(By.XPath("//input[@id='description']"));

        public IWebElement FoodPicture => driver.FindElement(By.XPath("//input[@id='url']"));

        public IWebElement AddButton => driver.FindElement(By.XPath("//button[@class='btn btn-primary btn-block fa-lg gradient-custom-2 mb-3']"));
    }
}
