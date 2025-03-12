using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SumNumApp
{
    public class SumNumberPage
    {
        private readonly IWebDriver driver;

        public SumNumberPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        const string PageUrl = "file:///C:/Users/Raya/OneDrive/Desktop/Desi's%20stuff/Front-End%20Technologies/2.%20Front-End%20Test%20Automation/04.%20Selenium%20WebDriver%20POM/04.%20Lab/Resources/Sum-Num/sum-num.html";
        public IWebElement fieldNum1 => driver.FindElement(By.XPath("//input[@id='number1']"));
        public IWebElement fieldNum2 => driver.FindElement(By.XPath("//input[@id='number2']"));

        public IWebElement calcButton => driver.FindElement(By.XPath("//input[@id='calcButton']"));

        public IWebElement resultElement => 
            driver.FindElement(By.XPath("//div[@id='result']"));

        public void OpenPage()
        {
            driver.Navigate().GoToUrl(PageUrl);
        }

        public string SumTwoNumbers(string number1, string number2)
        {
            fieldNum1.SendKeys(number1);
            fieldNum2.SendKeys(number2);

            calcButton.Click();

            string result = resultElement.Text;
            return result;

            
        }
    }
}
