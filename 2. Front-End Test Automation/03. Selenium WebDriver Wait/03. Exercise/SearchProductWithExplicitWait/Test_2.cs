using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace SearchProductWithExplicitWait
{
    public class Tests
    {
        IWebDriver driver;

        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.Navigate().GoToUrl("http://practice.bpbonline.com/");
        }

        [Test]
        public void SearchForKeyboardExplicitWait()
        {
            var search = driver.FindElement(By.XPath("//input[@name='keywords']"));
            search.SendKeys("keyboard");

            var searchLoop = driver.FindElement(By.XPath("//input[@title=' Quick Find '] "));
            searchLoop.Click();

            //Set implicit wait to 0 
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(0);

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementExists(By.XPath("//a[text()='Microsoft Internet Keyboard PS/2']")));

            var productName = driver.FindElement(By.XPath("//a[text()='Microsoft Internet Keyboard PS/2']"));
            Assert.That(productName.Displayed, Is.True);

            wait.Until(ExpectedConditions.ElementExists(By.XPath("//span[text()='Buy Now']")));
            var BuyNowButton = driver.FindElement(By.XPath("//span[text()='Buy Now']"));
            BuyNowButton.Click();

            //Set back the implicit wait to 10 secs
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            var productNameInCart = driver.FindElement(By.XPath("//a//span[@class='newItemInCart']"));
            Assert.That(productNameInCart.Displayed, Is.True);
        }

        [Test]
        public void SearchForJunkExplicitWait()
        {
            var search = driver.FindElement(By.XPath("//input[@name='keywords']"));
            search.SendKeys("junk");

            var searchLoop = driver.FindElement(By.XPath("//input[@title=' Quick Find '] "));
            searchLoop.Click();

            //Set implicit wait to 0 
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(0);

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            try
            {
                wait.Until(ExpectedConditions.ElementExists(By.XPath("//span[text()='Buy Now']")));
                var BuyNowButton = driver.FindElement(By.XPath("//span[text()='Buy Now']"));
                BuyNowButton.Click();
                Assert.Fail("Buy button was present on the page");
            }
            catch (WebDriverTimeoutException ex)
            {
                Assert.Pass("Buy button was not present on the page");
            }
            finally
            {
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            }

            var myCartTitle = driver.FindElement(By.XPath("//h1"));
            Assert.That(myCartTitle.Displayed, Is.True);
        }

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
            driver.Dispose();
        }
    }
}