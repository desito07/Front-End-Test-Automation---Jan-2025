using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System.Collections.ObjectModel;

namespace WorkingWithWindowHandlers
{
    public class Tests
    {
        IWebDriver driver;

        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/windows");
        }

        [Test]
        public void HandleMultipleWindows()
        {
            ReadOnlyCollection<string> windowHandelsIDsBefore = driver.WindowHandles;

            var clickHereButton = driver.FindElement(By.XPath("//a[text()='Click Here']"));
            clickHereButton.Click();

            ReadOnlyCollection<string> windowHandelsIDs = driver.WindowHandles;

            driver.SwitchTo().Window(windowHandelsIDs[1]);

            Assert.That(windowHandelsIDs.Count, Is.EqualTo(2));

            var newWindow = driver.FindElement(By.XPath("//h3"));
            Assert.That(newWindow.Text, Is.EqualTo("New Window"));

            driver.SwitchTo().Window(windowHandelsIDs[0]);
        }

        [Test]
        public void NoSuchWindowInteraction()
        {
            var clickHereButton = driver.FindElement(By.XPath("//a[text()='Click Here']"));
            clickHereButton.Click();

            ReadOnlyCollection<string> windowHandels = driver.WindowHandles;

            driver.SwitchTo().Window(windowHandels[1]);
            driver.Close();

            try
            {
                driver.SwitchTo().Window(windowHandels[1]);
            }
            catch (NoSuchWindowException ex)
            {
                Assert.Pass("Window was closed");
            }
            finally
            {
                driver.SwitchTo().Window(windowHandels[0]);
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