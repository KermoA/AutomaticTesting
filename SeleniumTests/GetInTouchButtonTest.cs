using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace SeleniumTests
{
    [TestFixture]
    public class GetInTouchButtonTest
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

            // Find the Get in Touch button using its name or xPath attribute
            var button = driver.FindElement(By.Id("get-in-touch"));

            // Wait after finding button
            Thread.Sleep(2000);  // Replace with explicit wait if needed

            // Click the Get in Touch button
            button.Click();

            // Wait for the contact page to load
            Thread.Sleep(2000);  // Replace with explicit wait if needed

            // Verify that the current URL is the expected one
            Assert.That(driver.Url, Is.EqualTo("https://kermoanijarv23.thkit.ee/contact/"), 
                "The button did not redirect to the expected contact page.");
        }

        [TearDown]
        public void Teardown()
        {
            // Close the browser and dispose of the driver
            driver?.Quit();
        }
    }
}