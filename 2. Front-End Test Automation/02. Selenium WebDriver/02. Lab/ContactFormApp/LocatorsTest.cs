using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace ContactFormApp
{
    public class Tests
    {
        public IWebDriver driver;

        [SetUp]
        public void Setup()
        {
            var options = new ChromeOptions();
            options.AddArgument("--headless=new");
            options.AddArgument("--window-size=1920,1200");
            
            driver = new ChromeDriver(options);
            driver.Navigate().GoToUrl("file:///C:/Users/Raya/OneDrive/Desktop/Desi's%20stuff/Front-End%20Technologies/2.%20Front-End%20Test%20Automation/02.%20Selenium%20WebDriver/02.%20Lab/ContactFormApp/Locators.html");
        }

        [Test]
        public void LocatorsTest()
        {
            //basic locators
            driver.FindElement(By.Id("lname")).SendKeys("LastName");
            driver.FindElement(By.Name("newsletter")).SendKeys("NewNewsletter");
            driver.FindElement(By.ClassName("information"));
            
            var findTagName = driver.FindElement(By.TagName("a"));
            Console.WriteLine(findTagName.Text);

            //text link locators
            driver.FindElement(By.LinkText("Softuni Official Page")).Click();
            //driver.FindElement(By.PartialLinkText("Softuni")).Click();

            //CCS selectors
            var firstNameInput = driver.FindElement(By.CssSelector("[id=fname]"));

            firstNameInput.Clear();
            firstNameInput.SendKeys("FirstName");

            driver.FindElement(By.CssSelector("div.additional-info > p > input[type='text']"));

            driver.FindElement(By.CssSelector("form > div.additional-info > p > input[type=text]"));

            //XPath locators
            var lastName = driver.FindElement(By.XPath("//input[@name='lname']"));
            lastName.Clear();
            lastName.SendKeys("LastName");

            var phoneNumber = driver.FindElement(By.XPath("//form[@action='thankyou.html']//div[@class='additional-info']//input[@type='text']"));
            phoneNumber.SendKeys("07864000000");

            //locators extended
            var submitButton = driver.FindElement(By.XPath("//input[@class='button']"));

            Assert.That(submitButton.Displayed);
            Assert.That(submitButton.Enabled);
        }

        [Test]
        public void FormSubmittion()
        {
            //assert title
            var formTitle = driver.FindElement(By.XPath("//h2"));
            Assert.That(formTitle.Text, Is.EqualTo("Contact Form"));

            //select male radio button
            var maleRadioButton = driver.FindElement(By.XPath("//input[@value='m']"));
            maleRadioButton.Click();
            Assert.That(maleRadioButton.Selected);

            //first name input
            var firstNameInput = driver.FindElement(By.XPath("//input[@id='fname']"));
            firstNameInput.Clear();
            firstNameInput.SendKeys("Butch");
            Assert.That(firstNameInput.GetAttribute("value"), Is.EqualTo("Butch"));

            //last name input
            var lastNameInput = driver.FindElement(By.XPath("//input[@id='lname']"));
            lastNameInput.Clear();
            lastNameInput.SendKeys("Coolidge");
            Assert.That(lastNameInput.GetAttribute("value"), Is.EqualTo("Coolidge"));

            //additional information section is present
            var additionalInfo = driver.FindElement(By.XPath("//h3"));
            Assert.That(additionalInfo.Text, Is.EqualTo("Additional Information"));

            //phone number input
            var phoneNumberInput = driver.FindElement(By.XPath("//div[@class='additional-info']//p//input[@type='text']"));
            phoneNumberInput.SendKeys("0888999777");
            Assert.That(phoneNumberInput.GetAttribute("value"), Is.EqualTo("0888999777"));

            //newsletter selection
            var newsletterBox = driver.FindElement(By.XPath("//input[@name='newsletter']"));
            newsletterBox.Click();
            Assert.That(newsletterBox.Selected);

            //submit button
            var submitButton = driver.FindElement(By.XPath("//input[@class='button']"));
            submitButton.Click();

            //thank you message
            var thankyouMessage = driver.FindElement(By.XPath("//h1"));
            Assert.That(thankyouMessage.Text, Is.EqualTo("Thank You!"));
        }

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
            driver.Dispose();
        }
    }
}