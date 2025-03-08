using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace SelenuimWaits_6_CustomWaits
{
    public class Tests_6
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

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5))
            {
                PollingInterval = TimeSpan.FromMilliseconds(100),

            };

            wait.IgnoreExceptionTypes(typeof(ElementNotInteractableException));

            wait.Until(drv =>
            {
                addBox.SendKeys("Displayed");
                return true;
            });

            Assert.That(addBox.Displayed, Is.True);
        }

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
            driver.Dispose();
        }


    }
}