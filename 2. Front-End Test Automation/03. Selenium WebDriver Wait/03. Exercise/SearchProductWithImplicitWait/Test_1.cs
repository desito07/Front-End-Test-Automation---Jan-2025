using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;


namespace SearchProductWithImplicitWait
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
        public void SearchForKeyboard()
        {
            var search = driver.FindElement(By.XPath("//input[@name='keywords']"));
            search.SendKeys("keyboard");

            var searchLoop = driver.FindElement(By.XPath("//input[@title=' Quick Find '] "));
            searchLoop.Click();

            var productName = driver.FindElement(By.XPath("//a[text()='Microsoft Internet Keyboard PS/2']"));
            Assert.That(productName.Displayed, Is.True);

            var BuyNowButton = driver.FindElement(By.XPath("//span[text()='Buy Now']"));
            BuyNowButton.Click();

            var myCartTitle = driver.FindElement(By.XPath("//h1"));
            Assert.That(myCartTitle.Displayed, Is.True);

            var productNameInCart = driver.FindElement(By.XPath("//a//span[@class='newItemInCart']"));
            Assert.That(productNameInCart.Displayed, Is.True);
        }

        [Test]
        public void SearchForJunk()
        {
            var search = driver.FindElement(By.XPath("//input[@name='keywords']"));
            search.SendKeys("junk");

            var searchLoop = driver.FindElement(By.XPath("//input[@title=' Quick Find '] "));
            searchLoop.Click();

            try
            {
                var BuyNowButton = driver.FindElement(By.XPath("//span[text()='Buy Now']"));
                BuyNowButton.Click();
            }
            catch (NoSuchElementException ex)
            {
                Assert.Pass("No such element exception has been thrown");
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