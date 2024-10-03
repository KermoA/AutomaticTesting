using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace SeleniumTests
{
    [TestFixture]
    public class ScrollToTopButtonTest
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

            // Scroll down to ensure the page is not at the top
            ((IJavaScriptExecutor)driver).ExecuteScript("window.scrollTo(0, 1500);");

            // Find the scroll-to-top button
            var button = driver.FindElement(By.Id("ast-scroll-top"));

            // Wait after finding button
            System.Threading.Thread.Sleep(2000);

            // Click the scroll-to-top button
            button.Click();

            // Wait for a moment to allow the UI to update
            System.Threading.Thread.Sleep(2000);

            // Verify that the page has scrolled to the top
            var scrollYPosition = (long)((IJavaScriptExecutor)driver).ExecuteScript("return window.scrollY;");
            Assert.That(scrollYPosition, Is.EqualTo(0), "The page did not scroll to the top after clicking the button.");
        }

        [TearDown]
        public void Teardown()
        {
            // Close the browser and dispose of the driver
            driver?.Quit();
        }
    }
}