using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System.Data;


namespace WebDriverWaitDemo
{
    public class Tests
    {
        IWebDriver driver;

        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://www.selenium.dev/selenium/web/dynamic.html");
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
        }

        [Test]
        public void TestRedBox()
        {
            var addBox = driver.FindElement(By.XPath("//input[@id='adder']"));
            addBox.Click();

            var redBox = driver.FindElement(By.XPath("//div[@class='redbox']"));
            Assert.That(redBox.Displayed, Is.True);

        }

        [Test] 
        public void TestInput()
        {
            var revealInput = driver.FindElement(By.XPath("//input[@id='reveal']"));
            revealInput.Click();

            var revealedInput = driver.FindElement(By.XPath("//input[@id='revealed']"));

            //Put explicit wait
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//input[@id='revealed']")));
            Assert.That(revealedInput.Displayed, Is.True);

        }

        [Test]

        public void TestFluentWait()
        {
            var revealInput = driver.FindElement(By.XPath("//input[@id='reveal']"));
            revealInput.Click();

            var revealedInput = driver.FindElement(By.XPath("//input[@id='revealed']"));

            DefaultWait<IWebDriver> wait = new DefaultWait<IWebDriver>(driver)
            {
                Timeout = TimeSpan.FromSeconds(5),
                PollingInterval = TimeSpan.FromMilliseconds(100)
            };

            wait.IgnoreExceptionTypes(typeof(NotFoundException));

            IWebElement inputElement = wait.Until(drv => drv.FindElement(By.XPath("//input[@id='reveal']")));

            Assert.That(inputElement.Displayed, Is.True);

        }

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
            driver.Dispose();
        }
    }
}