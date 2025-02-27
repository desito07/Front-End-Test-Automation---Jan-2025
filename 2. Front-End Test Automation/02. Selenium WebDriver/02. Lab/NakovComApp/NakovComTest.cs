using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;

namespace NakovComApp
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void NakovComTest()
        {
            // create home driver and open new browser
            IWebDriver driver = new ChromeDriver();

            //navigate to url
            driver.Navigate().GoToUrl("https://nakov.com/");

            var title = driver.Title;
            Assert.That(title.Contains("Svetlin Nakov"));

            var searchButton = driver.FindElement(By.XPath("//li[@id='sh']//a[@class='smoothScroll']"));

            Assert.That(searchButton.Text, Is.EqualTo("SEARCH"));
            searchButton.Click();

            //locate the search input
            var searchBox = driver.FindElement(By.Id("s"));

            Assert.That(searchBox.GetAttribute("placeholder"), Is.EqualTo("Search this site"));

            //type input
            Console.WriteLine(searchBox);

            //close the browser
            driver.Quit();






        }
    }
}