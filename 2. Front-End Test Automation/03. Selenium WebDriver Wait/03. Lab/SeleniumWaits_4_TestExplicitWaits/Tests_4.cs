using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace SeleniumWaits_4_TestExplicitWaits
{
    public class Tests_4
    {
        IWebDriver driver;

        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://www.selenium.dev/selenium/web/dynamic.html");
        }


        [Test]
        public void Test_1_RedBox()
        {
            var addBox = driver.FindElement(By.XPath("//input[@id='adder']"));
            addBox.Click();

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            wait.Until(ExpectedConditions.ElementExists(By.XPath("//div[@class='redbox']")));

            var redBox = driver.FindElement(By.XPath("//div[@class='redbox']"));

            Assert.That(redBox.Displayed, Is.True);
        }

        [Test]
        public void Test_2_Input()
        {
            var revealInput = driver.FindElement(By.XPath("//input[@id='reveal']"));
            revealInput.Click();

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            
            var revealedInput = driver.FindElement(By.XPath("//input[@id='revealed']"));

            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//input[@id='revealed']")));

            Assert.That(revealedInput.Displayed, Is.True);

        }

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
            driver.Dispose();
        }


    }
}