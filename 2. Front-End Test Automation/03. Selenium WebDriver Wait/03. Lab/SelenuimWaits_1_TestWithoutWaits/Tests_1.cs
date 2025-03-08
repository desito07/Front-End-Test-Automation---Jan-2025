using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System.Data;

namespace SeleniumWaits_1_TestWithoutWaits
{
    public class Tests_1
    {
        IWebDriver driver;

        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://www.selenium.dev/selenium/web/dynamic.html");
        }

        //Test will fail because there is no wait
        [Test]
        public void Test_1_RedBox()
        {
            var addBox = driver.FindElement(By.XPath("//input[@id='adder']"));
            addBox.Click();

            var redBox = driver.FindElement(By.XPath("//div[@class='redbox']"));
            Assert.That(redBox.Displayed, Is.True);
        }

        //Test will fail because there is no wait
        [Test]
        public void Test_2_Input()
        {
            var revealInput = driver.FindElement(By.XPath("//input[@id='reveal']"));
            revealInput.Click();

            var revealedInput = driver.FindElement(By.XPath("//input[@id='revealed']"));
                        
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