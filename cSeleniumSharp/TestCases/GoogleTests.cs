using System;

using OpenQA.Selenium;
// Requires reference to WebDriver.Support.dll
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Chrome;
using cSeleniumSharp.PageObjects;

using NUnit.Framework;

namespace cSeleniumSharp.TestCase
{
    [TestFixture]
    class GoogleTests
    {
        private IWebDriver driver;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            driver = new ChromeDriver();
        }


        [SetUp]
        public void SetUp()
        {
            driver.Navigate().GoToUrl("http://www.google.com/");
        }

        [Test]
        public void TestCheese()
        {

            Google google = new Google(driver);
            google.Search("Cheese");

            // Google's search is rendered dynamically with JavaScript.
            // Wait for the page to load, timeout after 10 seconds
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(d => d.Title.StartsWith("cheese", StringComparison.OrdinalIgnoreCase));

            // Should see: "Cheese - Google Search" (for an English locale)
            Console.WriteLine("Page title is: " + driver.Title);

            Assert.That("Cheese - Google Search", Is.EqualTo(driver.Title));
            Assert.AreEqual("Cheese - Google Search", driver.Title);
        }

        [Test]
        public void TestBread()
        {

            Google google = new Google(driver);
            google.Search("Bread");

            // Google's search is rendered dynamically with JavaScript.
            // Wait for the page to load, timeout after 10 seconds
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(d => d.Title.StartsWith("Bread", StringComparison.OrdinalIgnoreCase));

            // Should see: "Bread - Google Search" (for an English locale)
            Console.WriteLine("Page title is: " + driver.Title);

            Assert.That("Bread - Google Search", Is.EqualTo(driver.Title));
            Assert.AreEqual("Bread - Google Search", driver.Title);
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            driver.Dispose();
        }
    }
}
