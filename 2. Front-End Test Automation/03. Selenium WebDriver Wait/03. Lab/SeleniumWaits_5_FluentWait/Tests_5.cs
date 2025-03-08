using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;


namespace SeleniumWaits_5_FluentWait
{
    public class Tests_5
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

            DefaultWait<IWebDriver> fluentWait = new DefaultWait<IWebDriver>(driver);
            fluentWait.Timeout = TimeSpan.FromSeconds(3);
            fluentWait.PollingInterval = TimeSpan.FromMilliseconds(100);

            fluentWait.IgnoreExceptionTypes(typeof(NotFoundException));

            IWebElement redBox = fluentWait.Until(drv => drv.FindElement(By.XPath("//div[@class='redbox']")));

                        
            Assert.That(redBox.Displayed, Is.True);
        }

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
            driver.Dispose();
        }
    }
}