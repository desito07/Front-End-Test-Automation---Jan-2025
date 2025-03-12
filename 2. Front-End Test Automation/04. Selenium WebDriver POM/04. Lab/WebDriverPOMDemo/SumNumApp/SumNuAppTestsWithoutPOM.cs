using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SumNumApp
{
   public class SumNuAppTestsWithoutPOM
    {
        IWebDriver driver;

        private SumNumberPage sumPage;

        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            
            sumPage = new SumNumberPage(driver);
            sumPage.OpenPage();
        }

        [Test]
        public void TestWithCorrectData()
        {
            //var result = sumPage.SumTwoNumbers("10", "10");
            Assert.That(sumPage.SumTwoNumbers("10", "10"), Is.EqualTo("Sum: 20"));
        }

        [Test]
        public void TestWithInCorrectData()
        {
            //var result = sumPage.SumTwoNumbers("InvalidData", "10");
            Assert.That(sumPage.SumTwoNumbers("InvalidData", "10"), Is.EqualTo("Sum: invalid input"));
        }

        /*public void SumToNumbers(string number1, string number2)
        {
            sumPage.fieldNum1.SendKeys(number1);
            sumPage.fieldNum2.SendKeys(number2);

            sumPage.calcButton.Click();
        }*/

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
            driver.Dispose();
        }
    }
}
