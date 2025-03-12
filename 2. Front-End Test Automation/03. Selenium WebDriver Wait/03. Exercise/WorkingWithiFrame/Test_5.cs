using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace WorkingWithiFrame
{
    public class Tests
    {
        IWebDriver driver;

        WebDriverWait wait;

        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));

            driver.Navigate().GoToUrl("https://codepen.io/pervillalva/full/abPoNLd");


        }

        [Test]
        public void TestiFrameByIndex()
        {
            //driver.SwitchTo().Frame(0);

            wait.Until(ExpectedConditions.FrameToBeAvailableAndSwitchToIt(By.XPath("//iframe[@id='result']")));
            driver.FindElement(By.XPath("//button[@class='dropbtn']")).Click();

            var dropDownOptions = wait.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath("//div[@class='dropdown-content']//a")));

            foreach(var dropDownOption in dropDownOptions)
            {
                Console.WriteLine(dropDownOption.Text);
                Assert.That(dropDownOption.Displayed, Is.True);
            }
        }

        [Test]
        public void TestiFrameByID()
        {
            driver.SwitchTo().Frame("result");

            //wait.Until(ExpectedConditions.FrameToBeAvailableAndSwitchToIt(By.XPath("//iframe[@id='result']")));
            driver.FindElement(By.XPath("//button[@class='dropbtn']")).Click();

            var dropDownOptions = wait.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath("//div[@class='dropdown-content']//a")));

            foreach (var dropDownOption in dropDownOptions)
            {
                Console.WriteLine(dropDownOption.Text);
                Assert.That(dropDownOption.Displayed, Is.True);
            }
        }

        [Test]
        public void TestiFrameByWebElement()
        {
            wait.Until(ExpectedConditions.FrameToBeAvailableAndSwitchToIt(By.XPath("//iframe")));

            driver.FindElement(By.XPath("//button[@class='dropbtn']")).Click();

            var dropDownOptions = wait.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath("//div[@class='dropdown-content']//a")));

            foreach (var dropDownOption in dropDownOptions)
            {
                Console.WriteLine(dropDownOption.Text);
                Assert.That(dropDownOption.Displayed, Is.True);
            }
        }

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
            driver.Dispose();
        }

    }
}