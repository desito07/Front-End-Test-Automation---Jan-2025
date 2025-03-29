using FoodAppPOM.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
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
        public string searchField;
        public string searchButton;

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

        [Test, Order(3)]
        public void EditLastAddedFoodTest()
        {
            myFoodPage.OpenPage();

            myFoodPage.EditButtonLastFood.Click();

            string updatedName = "Updated Name: " + lastAddedFoodName;

            editFoodPage.FoodName.Clear();
            editFoodPage.FoodName.SendKeys(updatedName);
            editFoodPage.AddButton.Click();

            Assert.That(driver.Url, Is.EqualTo(myFoodPage.Url), "Not correctly redirected");

            Assert.That(myFoodPage.TitleLastFood.Text.Trim(), Is.EqualTo(lastAddedFoodName), "Name do not match");
         }

        [Test, Order(4)]
        public void SearchForFoodTest()
        {
            myFoodPage.OpenPage();
            myFoodPage.searchField.SendKeys(lastAddedFoodName);
            myFoodPage.searchButton.Click();

            Assert.That(myFoodPage.TitleLastFood.Text.Trim(), Is.EqualTo(lastAddedFoodName), "Name do not match");
        }

        [Test, Order(5)]
        public void DeleteLastAddedFoodTest()
        {
            myFoodPage.OpenPage();

            myFoodPage.DeleteButtonLastFood.Click();

            bool isLastFoodDeleted = myFoodPage.FoodCards.All(food => food.Text.Contains(lastAddedFoodName));

            Assert.IsFalse(isLastFoodDeleted, "The food was not deleted");
        }

        [Test, Order(6)]
        public void SearchForDeletedFoodTest()
        {
            myFoodPage.OpenPage();
            myFoodPage.searchField.SendKeys(lastAddedFoodName);
            myFoodPage.searchButton.Click();

            Assert.That(myFoodPage.noFoodMessage.Text.Trim(), Is.EqualTo("There are no foods :("), "The message that no foos is not dispalyed as expected.");
        }
    }
}
