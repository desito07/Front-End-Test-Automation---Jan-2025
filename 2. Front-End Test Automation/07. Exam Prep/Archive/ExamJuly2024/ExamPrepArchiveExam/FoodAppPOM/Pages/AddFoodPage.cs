using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodAppPOM.Pages
{
    internal class AddFoodPage : BasePage
    {
        public AddFoodPage(IWebDriver driver) : base(driver)
        {

        }

        public string Url = BaseUrl + "/Food/Add";

        public IWebElement FoodName => driver.FindElement(By.XPath("//input[@id='name']"));
        public IWebElement FoodDescription => driver.FindElement(By.XPath("//input[@id='description']"));

        public IWebElement FoodPicture => driver.FindElement(By.XPath("//input[@id='url']"));

        public IWebElement AddButton => driver.FindElement(By.XPath("//button[@class='btn btn-primary btn-block fa-lg gradient-custom-2 mb-3']"));

        public IWebElement MainMessage => driver.FindElement(By.XPath("//li[text()='Unable to add this food revue!']"));

        public IWebElement NameErrorMessage => driver.FindElements(By.XPath("//span[@class='text-danger field-validation-error']"))[0];

        public IWebElement DescriptionErrorMessage => driver.FindElements(By.XPath("//span[@class='text-danger field-validation-error']"))[1];

        public void AddFood(string name, string picture, string description)
        {
            FoodName.SendKeys(name);
            FoodPicture.SendKeys(picture);
            FoodDescription.SendKeys(description);

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementToBeClickable(AddButton));
            AddButton.Click();
        }

        public void AssertErrorMessages()
        {
            Assert.True(MainMessage.Text.Equals("Unable to add this food revue!"), "Main message is not as expected");

            Assert.True(NameErrorMessage.Text.Equals("The Name field is required."), "Name field is not as expected");

            Assert.True(DescriptionErrorMessage.Text.Equals("The Description field is required."), "Description field is not as expected");
        }

        public void OpenPage()
        {
            driver.Navigate().GoToUrl(Url);
        }
    }
}
