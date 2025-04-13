using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FETestAutomation_Exam130425.Pages
{
    public class DeleteMoviePage : BasePage
    {
        public DeleteMoviePage(IWebDriver driver) : base(driver)
        {

        }

        public string Url = BaseUrl + "/Events/Delete/";

        public IWebElement YesButton => driver.FindElement(By.XPath("//button[@class='btn warning']"));
        public IWebElement NoButton => driver.FindElement(By.XPath("//a[@class='btn btn-success']"));
    }
}
