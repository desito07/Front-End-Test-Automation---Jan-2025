using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodAppPOM.Pages
{
    public class EditFoodPage :BasePage
    {
        public EditFoodPage(IWebDriver driver) : base(driver)
        {

        }

        public string Url = BaseUrl + "/Food/Edit";
    }
}
