using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentRegistryPOM.Pages
{
    public class ViewStudents : BasePage
    {
        public ViewStudents(IWebDriver driver) : base(driver) { }

        public override string PageUrl => "http://localhost:8080/students";

        public ReadOnlyCollection<IWebElement> ListOfStudents => driver.FindElements(By.XPath("//ul//li"));

        public string[] GetRegisteredStudents()
        {
            var elementsStudents = ListOfStudents.Select(s => s.Text).ToArray();
            return elementsStudents;
        }
        
    }
}
