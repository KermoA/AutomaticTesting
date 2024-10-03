using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;

namespace SeleniumTests
{
    [TestFixture]
    public class WebsiteTest
    {
        private IWebDriver? driver;

        [SetUp]
        public void Setup()
        {
            // Initialize the ChromeDriver
            driver = new ChromeDriver();
            // Maximize the browser window
            driver.Manage().Window.Maximize();
            // Set an implicit wait time
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
        }

        [Test]
        public void TestHomePageLoad()
        {
            // Navigate to the website
            driver!.Navigate().GoToUrl("http://kermoanijarv23.thkit.ee");

            // Wait for the page to load completely
            driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(1000);

            // Check the title of the page
            string pageTitle = driver.Title;
            Assert.That(pageTitle, Is.EqualTo("SkateBlog"), "The page title did not match.");
        }

        [TearDown]
        public void TearDown()
        {
            // Close the browser and dispose of the driver
            driver?.Quit();
        }
    }
}

