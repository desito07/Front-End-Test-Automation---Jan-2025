using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace WorkingWithAlerts
{
    public class Tests
    {
        IWebDriver driver;

        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/javascript_alerts");
        }

        [Test]
        public void HandleBasicAlert()
        {
            driver.FindElement(By.XPath("//button[@onclick='jsAlert()']")).Click();

            IAlert alert = driver.SwitchTo().Alert();
            Assert.That(alert.Text, Is.EqualTo("I am a JS Alert"));
            alert.Accept();

            var result = driver.FindElement(By.XPath("//p[@id='result']"));
            Assert.That(result.Text, Is.EqualTo("You successfully clicked an alert"));
        }

        [Test]
        public void HandleConfirmAlert()
        {
            driver.FindElement(By.XPath("//button[@onclick='jsConfirm()']")).Click();

            IAlert alert = driver.SwitchTo().Alert();
            Assert.That(alert.Text, Is.EqualTo("I am a JS Confirm"));
            alert.Accept();

            var result = driver.FindElement(By.XPath("//p[@id='result']"));
            Assert.That(result.Text, Is.EqualTo("You clicked: Ok"));

            driver.FindElement(By.XPath("//button[@onclick='jsConfirm()']")).Click();
            IAlert newAlert = driver.SwitchTo().Alert();
            newAlert.Dismiss();

            var resultCanceled = driver.FindElement(By.XPath("//p[@id='result']"));
            Assert.That(result.Text, Is.EqualTo("You clicked: Cancel"));
        }

        [Test]
        public void HandlePromptAlert()
        {
            driver.FindElement(By.XPath("//button[@onclick='jsPrompt()']")).Click();

            IAlert alert = driver.SwitchTo().Alert();
            Assert.That(alert.Text, Is.EqualTo("I am a JS prompt"));

            string input = "Hello";
            alert.SendKeys(input);
            alert.Accept();

            var result = driver.FindElement(By.XPath("//p[@id='result']"));
            Assert.That(result.Text, Is.EqualTo($"You entered: {input}"));
        }
        [TearDown]
        public void TearDown()
        {
            driver.Quit();
            driver.Dispose();
        }
    }
}