using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;


namespace SelenuimWaits_2_TestThreadSleep
{
    
    public class Tests_2
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

            Thread.Sleep(5000);
            var redBox = driver.FindElement(By.XPath("//div[@class='redbox']"));
                        
            Assert.That(redBox.Displayed, Is.True);
        }

        [Test]
        public void Test_2_Input()
        {
            var revealInput = driver.FindElement(By.XPath("//input[@id='reveal']"));
            revealInput.Click();

            var revealedInput = driver.FindElement(By.XPath("//input[@id='revealed']"));

            Thread.Sleep(5000);
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