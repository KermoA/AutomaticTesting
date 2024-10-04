using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace SeleniumTests
{
    [TestFixture]
    public class SubmitCommentWithEmptyFieldsErrorTest
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

            // Find the image with alt='blog3' using CSS selector
            var imageElement = driver.FindElement(By.CssSelector("img[alt='blog3']"));

            // Click on the image to navigate to the blog page
            imageElement.Click();

            // Wait for the blog page to load
            Thread.Sleep(3000);

            // Find the submit button by id="submit"
            var submitButton = driver.FindElement(By.Id("submit"));

            // Click the submit button without filling the form to trigger the error
            submitButton.Click();

            // Wait for the error message to appear
            Thread.Sleep(2000);

            // Find the error message by class name using CSS selector
            var errorMessage = driver.FindElement(By.CssSelector(".wp-die-message"));

            // Verify that the error message text is as expected
            Assert.That(errorMessage.Text, Is.EqualTo("Error: Please fill the required fields."),
                "The error message is not as expected.");
        }

        [TearDown]
        public void Teardown()
        {
            // Close the browser and dispose of the driver
            driver?.Quit();
        }
    }
}
