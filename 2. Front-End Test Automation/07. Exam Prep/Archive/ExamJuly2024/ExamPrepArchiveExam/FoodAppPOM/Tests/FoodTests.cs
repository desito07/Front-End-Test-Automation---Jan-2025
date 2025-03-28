using FoodAppPOM.Pages;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodAppPOM.Tests
{
    public  class FoodTests : BaseTest
    {

        public string lastAddedFoodName;
        public string lastAddedFoodDescription;

        [Test, Order(1)]
        public void AddFoodWithInvalidDataTest()
        {
            addFoodPage.OpenPage();

            addFoodPage.AddFood("", "", "");

            addFoodPage.AssertErrorMessages();
        }

        [Test, Order(2)]
        public void AddFoodWithValidDataTest()
        {

            lastAddedFoodName = "Food " + GenerateRandomString(5);
            lastAddedFoodDescription = "Description " + GenerateRandomString(5);

            addFoodPage.OpenPage();

            addFoodPage.AddFood(lastAddedFoodName, "", lastAddedFoodDescription);

            Assert.That(driver.Url, Is.EqualTo(myFoodPage.Url), "Url is not correct");

            Assert.That(myFoodPage.TitleLastFood.Text.Trim(), Is.EqualTo(lastAddedFoodName), "Title not matched");
        }
    }
}
