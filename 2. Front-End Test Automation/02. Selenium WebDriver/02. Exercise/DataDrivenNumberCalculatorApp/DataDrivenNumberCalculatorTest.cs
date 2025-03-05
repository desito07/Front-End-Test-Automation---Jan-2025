using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace DataDrivenNumberCalculatorApp
{
    public class Tests
    {
        IWebDriver driver;
        IWebElement firstSumElement;
        IWebElement dropDownOperation;
        IWebElement secondSumElement;
        IWebElement calculateButton;
        IWebElement resetButton;
        IWebElement resultElement;

        [OneTimeSetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.Navigate().GoToUrl("http://127.0.0.1:5500/number-calculator.html");

            firstSumElement = driver.FindElement(By.XPath("//input[@id='number1']"));
            dropDownOperation = driver.FindElement(By.XPath("//select[@id='operation']"));
            secondSumElement = driver.FindElement(By.XPath("//input[@id='number2']"));
            calculateButton = driver.FindElement(By.XPath("//input[@id='calcButton']"));
            resetButton = driver.FindElement(By.XPath("//input[@id='resetButton']"));
            resultElement = driver.FindElement(By.XPath("//div[@id='result']"));
        }

        public void Calculate(string firstNumber, string operation, string secondNumber, string expectedResult)
        {
            resetButton.Click();

            if (!string.IsNullOrEmpty(firstNumber))
            {
                firstSumElement.SendKeys(firstNumber);
            }

            if (!string.IsNullOrEmpty(secondNumber))
            {
                secondSumElement.SendKeys(secondNumber);
            }

            if (!string.IsNullOrEmpty(operation))
            {
                new SelectElement(dropDownOperation).SelectByText(operation);
            }

            calculateButton.Click();
            Assert.That(resultElement.Text, Is.EqualTo(expectedResult));
        }

        [Test]
        [TestCase("5", "+ (sum)", "5", "Result: 10")]
        [TestCase("10", "+ (sum)", "5", "Result: 15")]
        [TestCase("5", "+ (sum)", "20", "Result: 25")]
        [TestCase("10", "- (subtract)", "5", "Result: 5")]
        public void DataDrivenNumberCalculatorTest(string firstNumber, string operation, string secondNumber, string expectedResult)
        {
            Calculate(firstNumber, operation, secondNumber, expectedResult);
        }

        [OneTimeTearDown]
        public void TearDown()
        {
            driver.Quit();
            driver.Dispose();
        }
    }
}