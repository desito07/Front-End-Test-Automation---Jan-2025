using FoodAppPOM.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodAppPOM.Tests
{
    public class BaseTest
    {
        public IWebDriver driver;

        internal LoginPage loginPage;

        internal AddFoodPage addFoodPage;

        internal MyFoodPage myFoodPage; 

        public EditFoodPage editFoodPage;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            var chromeOptions = new ChromeOptions();
            chromeOptions.AddUserProfilePreference("profile.password_manager_enabled", false);
            chromeOptions.AddArgument("--disable-search-engine-choice-screen");

            driver = new ChromeDriver(chromeOptions);
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            loginPage = new LoginPage(driver);
            addFoodPage = new AddFoodPage(driver);
            myFoodPage = new MyFoodPage(driver);
            editFoodPage = new EditFoodPage(driver);
            
            loginPage.OpenPage();
            loginPage.Login("desi07", "123456");

        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            driver.Quit();
            driver.Dispose();
        }

        public string GenerateRandomString(int length)
        {
            const string chars = "zxcvbnmlkjhgfdsaqwertyuiop";
            var random = new Random();
            return new string(Enumerable.Repeat(chars, length).Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}
