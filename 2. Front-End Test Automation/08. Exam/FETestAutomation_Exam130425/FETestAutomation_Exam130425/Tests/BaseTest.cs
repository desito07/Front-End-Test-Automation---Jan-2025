using FETestAutomation_Exam130425.Pages;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FETestAutomation_Exam130425.Tests
{
    public class BaseTest
    {
        public IWebDriver driver;

        public LoginPage loginPage;

        public AddMoviePage addMoviePage;

        public AllMoviesPage allMoviesPage;

        public EditMoviePage editMoviePage;

        public WatchedMoviesPage watchedMoviesPage;

        public DeleteMoviePage deleteMoviePage;

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
            addMoviePage = new AddMoviePage(driver);
            allMoviesPage = new AllMoviesPage(driver);
            editMoviePage = new EditMoviePage(driver);
            watchedMoviesPage = new WatchedMoviesPage(driver);
            deleteMoviePage = new DeleteMoviePage(driver);

            loginPage.OpenPage();
            loginPage.Login("desitest@gmail.com", "desiTest123*");

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
