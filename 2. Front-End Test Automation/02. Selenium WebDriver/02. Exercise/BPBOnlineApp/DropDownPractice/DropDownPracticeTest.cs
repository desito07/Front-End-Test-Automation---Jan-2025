using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System.Collections.ObjectModel;

namespace DropDownPractice
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
        public void DropDownPracticeTest()
        {
            string path = System.IO.Directory.GetCurrentDirectory() + "manuafacturers.txt";

            if (File.Exists(path))
            {
                File.Delete(path);
            }

            SelectElement manufacturerDropdown = new SelectElement(driver.FindElement(By.Name("manufacturers_id")));

            IList<IWebElement> allManufacturersOptions = manufacturerDropdown.Options;

            List<string> manufacturersNames = new List<string>();

            foreach( var manElement in allManufacturersOptions)
            {
                manufacturersNames.Add(manElement.Text);
            }

            manufacturersNames.RemoveAt(0);

            foreach(var mname in manufacturersNames)
            {
                manufacturerDropdown.SelectByText(mname);

                manufacturerDropdown = new SelectElement(driver.FindElement(By.XPath("//select[@name='manufacturers_id']")));

                if(driver.PageSource.Contains("There are no products available in this category."))
                {
                    File.AppendAllText(path, $"The manufacturer {mname} has no products!");
                }
                else
                {
                    IWebElement table = driver.FindElement(By.XPath("//table[@class='productListingData']"));

                    File.AppendAllText(path, $"\n\n The manufaturer {mname} products are listed -- \n");

                    IReadOnlyCollection<IWebElement> tableRows = table.FindElements(By.XPath("//tbody//tr"));

                    foreach (var row in tableRows)
                    {
                        File.AppendAllText(path, row.Text + "\n");
                    }
                }
            }


        }

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
            driver.Dispose();
        }
    }
}