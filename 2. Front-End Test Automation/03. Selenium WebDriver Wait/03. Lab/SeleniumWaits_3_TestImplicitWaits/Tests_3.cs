using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;


namespace SeleniumWaits_3_TestImplicitWaits
{
    public class Tests_3
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

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3);

            var redBox = driver.FindElement(By.XPath("//div[@class='redbox']"));

            Assert.That(redBox.Displayed, Is.True);
        }

        //test will fail as element is present on page, but we need to be displayed
        [Test]
        public void Test_2_Input()
        {
            var revealInput = driver.FindElement(By.XPath("//input[@id='reveal']"));
            revealInput.Click();
                       
            var revealedInput = driver.FindElement(By.XPath("//input[@id='revealed']"));

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3);

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