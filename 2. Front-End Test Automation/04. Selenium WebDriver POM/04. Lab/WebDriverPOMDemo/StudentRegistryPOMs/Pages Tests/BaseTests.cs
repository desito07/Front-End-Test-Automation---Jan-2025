﻿using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentRegistryPOM.Pages_Tests
{
    public class BaseTests
    {
        protected IWebDriver driver;

        [OneTimeSetUp]

        public void OneTimeSetuP()
        {
            this.driver = new ChromeDriver();
        }

        [OneTimeTearDown]

        public void OneTimeTearDown()
        {
            driver.Quit();
            driver.Dispose();
        }
    }
}
