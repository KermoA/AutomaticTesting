using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace SeleniumTests
{
    [TestFixture]
    public class ContactFormTest
    {
        private IWebDriver? driver;

        [SetUp]
        public void Setup()
        {
            // Initialize the ChromeDriver instance
            driver = new ChromeDriver();
            
            // Maximize the browser window for better visibility
            driver.Manage().Window.Maximize();
            
            // Set an implicit wait time for locating elements (in seconds)
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
        }

        [Test]
        public void ButtonTest()
        {
            // Navigate to the target website
            driver!.Navigate().GoToUrl("http://kermoanijarv23.thkit.ee");

            // Find the 'Contact' Link from menu by its CSS selector using href and class
            var contactLink = driver.FindElement(By.CssSelector("a.menu-link[href='https://kermoanijarv23.thkit.ee/contact/']"));

            // Wait for 2 seconds to ensure the element is fully loaded
            Thread.Sleep(2000);

            // Click the 'Contact' Link to navigate to the Contact page
            contactLink.Click();

            // Wait for 2 seconds for the contact page to load
            Thread.Sleep(2000);

            // Find the name field on the contact form by its Id
            var nameField = driver.FindElement(By.Id("wpforms-6-field_0"));

            // Enter a name into the name field
            nameField.SendKeys("Asd");

            // Wait for 500 milliseconds after entering the name
            Thread.Sleep(500);

            // Find the email field on the contact form by its Id
            var emailField = driver.FindElement(By.Id("wpforms-6-field_1"));

            // Enter an email into the email field
            emailField.SendKeys("asd@msn.com");

            // Wait for 500 milliseconds after entering the email
            Thread.Sleep(500);

            // Find the message field on the contact form by its Id
            var messageField = driver.FindElement(By.Id("wpforms-6-field_2"));

            // Enter a message into the message field
            messageField.SendKeys("Asdfgh");

            // Wait for 500 milliseconds after entering the message
            Thread.Sleep(500);

            // Find the required email field on the contact form by its Id
            var requiredEmailField = driver.FindElement(By.Id("wpforms-6-field_5"));

            // Enter an email into the required email field
            requiredEmailField.SendKeys("asd@msn.com");

            // Wait for 500 milliseconds after entering the required email
            Thread.Sleep(500);

            // Find the 'Submit' button by its Id and click it to submit the form
            var sendMessageButton = driver.FindElement(By.Id("wpforms-submit-6"));

            // Click the 'Submit' button to send the form
            sendMessageButton.Click();

            // Wait for 1 second after submitting the form
            Thread.Sleep(1000);

            // Find the confirmation message by its Id
            var confirmationMessage = driver.FindElement(By.Id("wpforms-confirmation-6"));

            // Wait for 1 second after the confirmation message is displayed
            Thread.Sleep(1000);

            // Assert that the confirmation message matches the expected text
            Assert.That(confirmationMessage.Text, Is.EqualTo("Thanks for contacting us! We will be in touch with you shortly."),
                "The confirmation message is not as expected.");
        }

        [TearDown]
        public void Teardown()
        {
            // Close the browser and dispose of the driver after the test completes
            driver?.Quit();
        }
    }
}
