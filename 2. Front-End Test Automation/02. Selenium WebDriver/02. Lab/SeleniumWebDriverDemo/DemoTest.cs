using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace SeleniumWebDriverDemo
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void DemoTest()
        {
            // create home driver and open new browser
            IWebDriver driver = new ChromeDriver();

            //navigate to url
            driver.Navigate().GoToUrl("https://www.wikipedia.org/");

            //print page title
            Console.WriteLine("Main page title: " + driver.Title);

            //locate the search input
            var searchBox = driver.FindElement(By.Id("searchInput"));

            //type quality assurance input
            searchBox.SendKeys("Quality Assurance" + Keys.Enter);

            //print page title
            Console.WriteLine("Title after search: " + driver.Title);

            //close the browser
            driver.Quit();


        }
    }
}