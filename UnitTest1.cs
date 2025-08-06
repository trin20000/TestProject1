using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;
using WebDriverManager.Helpers;



namespace TestProject1
{
    [TestFixture]
    public class Tests
    {
        private IWebDriver driver;
        [SetUp]
        public void Setup()
        {
            new DriverManager().SetUpDriver(new ChromeConfig(), VersionResolveStrategy.MatchingBrowser);
            // Initialize ChromeDriver.
            // NuGet package automatically places chromedriver.exe in the output directory.
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize(); // Maximize the browser window
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10); // Set implicit wait

        }

        [Test]
        public void Test1()
        {
            // 1. Navigate to Google
            //driver.Navigate().GoToUrl("https://www.google.com");
            driver.Url = "https://www.google.com";
            // 2. Find the search input element by its name attribute
            IWebElement searchBox = driver.FindElement(By.Name("q"));

            // 3. Type "Vercel" into the search box
            searchBox.SendKeys("Vercel");

            // 4. Simulate pressing Enter (or click the search button)
            searchBox.SendKeys(Keys.Enter);

            try
            { // Create a WebDriverWait instance.
              // This will wait for a maximum of 10 seconds.
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

                // Wait until the title of the page is exactly "Your Page Title"
                wait.Until(ExpectedConditions.TitleIs("Vercel"));
            }

            catch (WebDriverTimeoutException)
            {
                Console.WriteLine("The page title did not appear in time.");
            }

            // 5. Assert that the page title contains "Vercel"
            // This waits for the title to change, which is good for dynamic pages
            Assert.That(driver.Title.Contains("Vercel"), "Page title does not contain 'Vercel'");

            Console.WriteLine($"Test 'SearchForVercel' completed. Page Title: {driver.Title}");
        }
        [Test]
        public void Test2()
        {
            driver.Navigate().GoToUrl("https://seleniumbase.io/demo_page");

            IWebElement textInput = driver.FindElement(By.XPath("/html/body/form/table/tbody/tr[2]/td[2]/input"));

            textInput.SendKeys("Vercel");

            string actualText = textInput.GetAttribute("value").Trim();

            Assert.AreEqual(actualText, "Vercel");

            Console.WriteLine($"Web Testing Page' completed. Page Title: {driver.Title}");
        }

        [Test]
        public void Test3()
        {
            //driver.Navigate().GoToUrl("https://seleniumbase.io/demo_page");
            driver.Url = "https://seleniumbase.io/demo_page";

            // Initialize Actions class
            Actions actions = new Actions(driver);

            //1.Locate the main menu item to hover over
            IWebElement mainMenu = driver.FindElement(By.XPath("/html/body/form/table/tbody/tr[1]/td[3]/div/div[1]"));
            


            textInput.SendKeys("Vercel");

            string actualText = textInput.GetAttribute("value").Trim();

            Assert.AreEqual("Vercel", "Vercel");

            Console.WriteLine($"Web Testing Page' completed. Page Title: {driver.Title}");
        }


        [TearDown] // NUnit attribute: method runs after each test
        public void Teardown()
        {
            //Close the browser after the test
            if (driver != null)
            {
               driver.Quit();
               driver.Dispose(); // Release resources
            }
        }
    }
}