using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SeleniumExtras.WaitHelpers;

namespace ExamPrepArchive1.Pages
{
    public class CreateIdeaPage : BasePage
    {
        public CreateIdeaPage(IWebDriver driver) : base(driver) 
        {
                    
        }

        public string Url = BaseUrl + "/Ideas/Create";
        
        public IWebElement TitleField => driver.FindElement(By.XPath("//input[@name='Title']"));

        public IWebElement ImageField => driver.FindElement(By.XPath("//input[@name='Url']"));

        public IWebElement DescriptionField => driver.FindElement(By.XPath("//textarea[@name='Description']"));

        public IWebElement CreateButton => driver.FindElement(By.XPath("//button[@class='btn btn-primary btn-lg']"));

        public IWebElement MainMessage => driver.FindElement(By.XPath("//div[@class='text-danger validation-summary-errors']//li"));

        public IWebElement TitleErrorMessage => driver.FindElements(By.XPath("//span[@class='text-danger field-validation-error']"))[0];

        public IWebElement DescriptionErrorMessage => driver.FindElements(By.XPath("//span[@class='text-danger field-validation-error']"))[1];

        public void CreateIdea(string title, string imageUrl, string description)
        {
            TitleField.SendKeys(title);
            ImageField.SendKeys(imageUrl);
            DescriptionField.SendKeys(description);

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(50));
            wait.Until(ExpectedConditions.ElementToBeClickable(CreateButton));
            CreateButton.Click();
        }

        public void AssertErrorMessages()
        {
            Assert.True(MainMessage.Text.Equals("Unable to create new Idea!"), "Main message is not as expected");

            Assert.True(TitleErrorMessage.Text.Equals("The Title field is required."), "Title field is not as expected");

            Assert.True(DescriptionErrorMessage.Text.Equals("The Description field is required."), "Description field is not as expected");
        }

        public void OpenPage()
        {
            driver.Navigate().GoToUrl(Url);
        }



    }
}
