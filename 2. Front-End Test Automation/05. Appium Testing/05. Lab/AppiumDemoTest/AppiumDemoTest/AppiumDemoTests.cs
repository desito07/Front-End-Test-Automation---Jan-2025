using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using System.Xml.XPath;

namespace AppiumDemoTest
{
    public class AppiumDemoTests
    {
        private AndroidDriver driver;

        [OneTimeSetUp]
        public void Setup()
        {
            var androidOption = new AppiumOptions();
            androidOption.PlatformName = "Android";
            androidOption.AutomationName = "UiAutomator2";
            androidOption.PlatformVersion = "16";
            androidOption.DeviceName = "AppiumDemoTest";
            androidOption.App = "c:\\com.example.androidappsummator.apk";

            driver = new AndroidDriver(androidOption);
        }

        [Test]
        public void Test_ValidData()
        {
            var field1 = driver.FindElement(MobileBy.XPath("//android.widget.EditText[@resource-id=\"com.example.androidappsummator:id/editText1\"]"));
            field1.Clear();
            field1.SendKeys("10");

            var field2 = driver.FindElement(MobileBy.XPath("//android.widget.EditText[@resource-id=\"com.example.androidappsummator:id/editText2\"]"));
            field2.Clear();
            field2.SendKeys("5");

            var calcButton = driver.FindElement(MobileBy.XPath("//android.widget.Button[@resource-id=\"com.example.androidappsummator:id/buttonCalcSum\"]"));
            calcButton.Click();

            var result = driver.FindElement(MobileBy.XPath("//android.widget.EditText[@resource-id=\"com.example.androidappsummator:id/editTextSum\"]"));

            Assert.That(result.Text, Is.EqualTo("15"));
        }

        [Test]
        public void Test_InValidData()
        {
            var field1 = driver.FindElement(MobileBy.XPath("//android.widget.EditText[@resource-id=\"com.example.androidappsummator:id/editText1\"]"));
            field1.Clear();
            field1.SendKeys("");

            var field2 = driver.FindElement(MobileBy.XPath("//android.widget.EditText[@resource-id=\"com.example.androidappsummator:id/editText2\"]"));
            field2.Clear();
            field2.SendKeys("!");

            var calcButton = driver.FindElement(MobileBy.XPath("//android.widget.Button[@resource-id=\"com.example.androidappsummator:id/buttonCalcSum\"]"));
            calcButton.Click();

            var result = driver.FindElement(MobileBy.XPath("//android.widget.EditText[@resource-id=\"com.example.androidappsummator:id/editTextSum\"]"));

            Assert.That(result.Text, Is.EqualTo("error"));
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            driver.Quit();
            driver.Dispose();
        }
    }
}