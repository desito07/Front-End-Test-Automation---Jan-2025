using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentRegistryPOM.Pages
{
    public class AddStudent : BasePage
    {
        public AddStudent(IWebDriver driver) : base(driver) { }

        public override string PageUrl => "http://localhost:8080/add-student";

        public IWebElement NameField => driver.FindElement(By.XPath("//input[@id='name']"));

        public IWebElement EmailField => driver.FindElement(By.XPath("//input[@id='email']"));

        public IWebElement AddButton => driver.FindElement(By.XPath("//button[@type='submit']"));

        public IWebElement ErrorMessage => driver.FindElement(By.XPath("//div[text()='Cannot add student. Name and email fields are required!']"));

        public void AddStudents(string name, string email)
        {
            this.NameField.SendKeys(name);
            this.EmailField.SendKeys(email);
            this.AddButton.Click();
        }
    }
}
