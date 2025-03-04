using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Collections.ObjectModel;

namespace WorkingWithWebTables
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
        public void WorkingWithWebTablesTest()
        {
            string path = System.IO.Directory.GetCurrentDirectory() + "productInformation.csv";

            if (File.Exists(path))
            {
                File.Delete(path);
            }

            IWebElement tableElement = driver.FindElement(By.XPath("//table"));

            ReadOnlyCollection<IWebElement> tableRows = tableElement.FindElements(By.XPath("//table//tbody//tr"));

            foreach(var tableRow in tableRows)
            {
                ReadOnlyCollection<IWebElement> tableData = tableRow.FindElements(By.TagName("td"));
                foreach (var currentTableData in tableData)
                {
                    String data = currentTableData.Text;
                    String[] productInfo = data.Split('\n');
                    String productInfoToWrite = productInfo[0] + "," + productInfo[1].Trim() + "\n";

                    File.AppendAllText(path, productInfoToWrite);

                }
            }

            Assert.That(File.Exists(path), Is.True, "CSV file was not created");
            Assert.That(new FileInfo(path).Length, Is.GreaterThan(0), "File is empty");
        }

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
            driver.Dispose();
        }
    }
}