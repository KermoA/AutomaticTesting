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

            // Find the Get in Touch button using its Id
            var contactLink = driver.FindElement(By.CssSelector("a.menu-link[href='https://kermoanijarv23.thkit.ee/contact/']"));

            // Wait after finding button
            Thread.Sleep(2000);

            // Click the Get in Touch button
            contactLink.Click();

            // Wait for the contact page to load
            Thread.Sleep(2000);

            var nameField = driver.FindElement(By.Id("wpforms-6-field_0"));

            nameField.SendKeys("Asd");

            Thread.Sleep(2000);

            var emailField = driver.FindElement(By.Id("wpforms-6-field_1"));

            emailField.SendKeys("asd@msn.com");

            Thread.Sleep(500);

            var messageField = driver.FindElement(By.Id("wpforms-6-field_2"));

            messageField.SendKeys("Asdfgh");

            Thread.Sleep(500);

            var requiredEmailField = driver.FindElement(By.Id("wpforms-6-field_5"));

            requiredEmailField.SendKeys("asd@msn.com");

            Thread.Sleep(500);

            var sendMessageButton = driver.FindElement(By.Id("wpforms-submit-6"));

            sendMessageButton.Click();

            Thread.Sleep(1000);

            var confirmationMessage = driver.FindElement(By.Id("wpforms-confirmation-6"));

            Thread.Sleep(1000);

            Assert.That(confirmationMessage.Text, Is.EqualTo("Thanks for contacting us! We will be in touch with you shortly."),
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