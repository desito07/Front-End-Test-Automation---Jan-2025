using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.DevTools.V133.Audits;
using OpenQA.Selenium.Support.UI;

namespace HandlingFormInput
{
    public class Tests
    {
        public IWebDriver driver;

        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.Navigate().GoToUrl("https://practice.bpbonline.com/");

        }

        [Test]
        public void HandlingFormInputTest()
        {
            var myAccountButton = driver.FindElement(By.XPath("//span[@class='ui-button-text']"));
            myAccountButton.Click();

            var continueButton = driver.FindElement(By.XPath("//span[text()='Continue']"));
            continueButton.Click();

            var createAnAccountLink = driver.FindElement(By.XPath("//u[text()='create an account']"));
            createAnAccountLink.Click();

            var maleRadioButton = driver.FindElement(By.XPath("//input[@value='m']"));
            maleRadioButton.Click();
            Assert.That(maleRadioButton.Selected);

            var firstName = driver.FindElement(By.XPath("//input[@name='firstname']"));
            firstName.SendKeys("Test First Name");

            var lastName = driver.FindElement(By.XPath("//input[@name='lastname']"));
            lastName.SendKeys("Test Last Name");

            var DOB = driver.FindElement(By.XPath("//input[@id='dob']"));
            DOB.SendKeys("01/01/2000" + Keys.Enter);

            Random random = new Random();
            int num = random.Next(1000, 9999);
            String email = "testFirstName.testLastName" + num.ToString() + "@gmail.com";
            var emailInput = driver.FindElement(By.XPath("//input[@name='email_address']"));
            emailInput.SendKeys(email);

            var companyName = driver.FindElement(By.XPath("//input[@name='company']"));
            companyName.SendKeys("Test Company");

            var streetAddress = driver.FindElement(By.XPath("//input[@name='street_address']"));
            streetAddress.SendKeys("1 Test Street");

            var suburb = driver.FindElement(By.XPath("//input[@name='suburb']"));
            suburb.SendKeys("Test Suburb");

            var postCode = driver.FindElement(By.XPath("//input[@name='postcode']"));
            postCode.SendKeys("TE12ST");

            var city = driver.FindElement(By.XPath("//input[@name='city']"));
            city.SendKeys("Test City");

            var state = driver.FindElement(By.XPath("//input[@name='state']"));
            state.SendKeys("Test State");

            new SelectElement(driver.FindElement(By.Name("country"))).SelectByText("Bulgaria");

            var phoneNumber = driver.FindElement(By.XPath("//input[@name='telephone']"));
            phoneNumber.SendKeys("0888999777");

            var newsletterBox = driver.FindElement(By.XPath("//input[@name='newsletter']"));
            newsletterBox.Click();
            Assert.That(newsletterBox.Selected);

            var password = driver.FindElement(By.XPath("//input[@name='password']"));
            password.SendKeys("123456");

            var passwordConfirm = driver.FindElement(By.XPath("//input[@name='confirmation']"));
            passwordConfirm.SendKeys("123456");

            var continueButtonEnd = driver.FindElement(By.XPath("//span[text()='Continue']"));
            continueButtonEnd.Click();

            var formCompletion = driver.FindElement(By.XPath("//h1"));
            Assert.IsTrue(driver.PageSource.Contains("Your Account Has Been Created!"), "Account creation failed.");

            var LogOffButton = driver.FindElement(By.XPath("//span[text()='Log Off']"));
            LogOffButton.Click();

            var continueButtonAccountCreated = driver.FindElement(By.XPath("//span[text()='Continue']"));
            continueButtonAccountCreated.Click();

            Console.WriteLine("User Account Created with email: " + email);
        }

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
            driver.Dispose();
        }
    }
}