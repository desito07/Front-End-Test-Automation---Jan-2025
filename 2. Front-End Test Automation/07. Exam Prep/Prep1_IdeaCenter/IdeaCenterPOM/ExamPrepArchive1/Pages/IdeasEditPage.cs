using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamPrepArchive1.Pages
{
    public class IdeasEditPage : BasePage
    {
        public IdeasEditPage(IWebDriver driver) : base(driver)
        {
            
        }

        public string Url = BaseUrl + "/Ideas/Create";

        public IWebElement TitleField => driver.FindElement(By.XPath("//input[@name='Title']"));

        public IWebElement ImageField => driver.FindElement(By.XPath("//input[@name='Url']"));

        public IWebElement DescriptionField => driver.FindElement(By.XPath("//textarea[@name='Description']"));

        public IWebElement EditButton => driver.FindElement(By.XPath("//button[@class='btn btn-primary btn-lg']"));
    }
}
