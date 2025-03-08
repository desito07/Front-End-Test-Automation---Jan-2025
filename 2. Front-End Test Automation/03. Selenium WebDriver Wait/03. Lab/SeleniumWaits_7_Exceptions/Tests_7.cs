using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace SeleniumWaits_7_Exceptions
{
    public class Tests
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

            Assert.Throws<NoSuchElementException>(() => driver.FindElement(By.XPath("//div[@class='redbox']")));
        }

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
            driver.Dispose();
        }
    }
}