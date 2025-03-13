using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentRegistryPOM.Pages
{
    public class HomePage : BasePage
    {
        public HomePage(IWebDriver driver) : base(driver)
        {

        }

        public override string PageUrl => "http://localhost:8080/";

        public IWebElement ElementsStudentsCount => driver.FindElement(By.XPath("//p//b"));

        public int GetStudentsCount()
        {
            return int.Parse(ElementsStudentsCount.Text);
        }
    }
}
