using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace SeleniumTests
{
    [TestFixture]
    public class DarkModeButtonTest
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
        public void ButtonTest()
        {
            // Navigate to the website
            driver!.Navigate().GoToUrl("http://kermoanijarv23.thkit.ee");

            // Find the toggle button
            var button = driver.FindElement(By.CssSelector(".dracula-toggle-icon"));

            // Find the <html> element to check for the data-dracula-scheme attribute
            var htmlElement = driver.FindElement(By.TagName("html"));

            // Verify the initial state (check if dark mode is enabled)
            Assert.That(htmlElement.GetAttribute("data-dracula-scheme"), Is.EqualTo("dark"), "Initial mode should be dark.");

            // Click the button to toggle the mode
            button.Click();

            // Wait for a moment to allow the UI to update
            System.Threading.Thread.Sleep(2000);

            // Verify that dark mode is now turned off (light mode)
            Assert.That(htmlElement.GetAttribute("data-dracula-scheme"), Is.Not.EqualTo("dark"), "Mode should be light after clicking.");

            // Click the button again to toggle back
            button.Click();

            // Wait for a moment to allow the UI to update
            System.Threading.Thread.Sleep(2000);

            // Verify that dark mode is back on
            Assert.That(htmlElement.GetAttribute("data-dracula-scheme"), Is.EqualTo("dark"), "Mode should be dark after clicking again.");
        }

        [TearDown]
        public void Teardown()
        {
            // Close the browser and dispose of the driver
            driver?.Quit();
        }
    }
}