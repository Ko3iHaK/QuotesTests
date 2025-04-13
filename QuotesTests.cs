using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Xunit;
using System;
using System.Threading;

namespace QuotesTests
{
    public class QuotesTests : IDisposable
    {
        private readonly IWebDriver driver;
        private readonly string baseUrl = "https://quotes.toscrape.com";

        public QuotesTests()
        {
            var options = new ChromeOptions();
            options.AddArgument("--headless");
            driver = new ChromeDriver(options);
        }

        public void Dispose()
        {
            driver.Quit();
        }

        [Fact]
        public void TestHomePageTitle()
        {
            driver.Navigate().GoToUrl(baseUrl);
            Assert.Contains("Quotes", driver.Title);
        }

        [Fact]
        public void TestFirstQuoteIsDisplayed()
        {
            driver.Navigate().GoToUrl(baseUrl);
            var firstQuote = driver.FindElement(By.CssSelector(".quote"));
            Assert.True(firstQuote.Displayed);
        }

        [Fact]
        public void TestAuthorLinkNavigation()
        {
            driver.Navigate().GoToUrl(baseUrl);
            var authorLink = driver.FindElement(By.CssSelector(".quote span a"));
            authorLink.Click();
            Assert.Contains("/author/", driver.Url);
        }

        [Fact]
        public void TestLoginLinkNavigation()
        {
            driver.Navigate().GoToUrl(baseUrl);
            var loginLink = driver.FindElement(By.LinkText("Login"));
            loginLink.Click();
            Thread.Sleep(2000);
            Assert.Contains("/login", driver.Url);
        }

        [Fact]
        public void TestLoginFormFieldsExist()
        {
            driver.Navigate().GoToUrl(baseUrl + "/login");
            var usernameField = driver.FindElement(By.Id("username"));
            var passwordField = driver.FindElement(By.Id("password"));
            Assert.True(usernameField.Displayed);
            Assert.True(passwordField.Displayed);
        }

        [Fact]
        public void TestLoginFormInput()
        {
            driver.Navigate().GoToUrl(baseUrl + "/login");
            var usernameField = driver.FindElement(By.Id("username"));
            usernameField.Clear();
            string testUsername = "testuser";
            usernameField.SendKeys(testUsername);
            Assert.Equal(testUsername, usernameField.GetAttribute("value"));
        }

        [Fact]
        public void TestLoginProcess()
        {
            driver.Navigate().GoToUrl(baseUrl + "/login");

            var usernameField = driver.FindElement(By.Id("username"));
            var passwordField = driver.FindElement(By.Id("password"));
            var loginButton = driver.FindElement(By.CssSelector("input[type='submit']"));

            usernameField.Clear();
            passwordField.Clear();

            usernameField.SendKeys("anyuser");
            passwordField.SendKeys("anypassword");
            loginButton.Click();

            // Проверка появления кнопки Logout как подтверждение успешного входа
            var logoutLink = driver.FindElement(By.LinkText("Logout"));
            Assert.True(logoutLink.Displayed);
        }


        [Fact]
        public void TestNextPageNavigation()
        {
            driver.Navigate().GoToUrl(baseUrl);
            var nextLink = driver.FindElement(By.CssSelector("li.next a"));
            nextLink.Click();
            Thread.Sleep(2000);
            Assert.Contains("page", driver.Url);
        }

        [Fact]
        public void TestTagLinkNavigation()
        {
            driver.Navigate().GoToUrl(baseUrl);
            var tagLink = driver.FindElement(By.CssSelector(".quote .tags a"));
            tagLink.Click();
            Thread.Sleep(2000);
            Assert.Contains("/tag/", driver.Url);
        }

        [Fact]
        public void TestQuoteCountGreaterThanZero()
        {
            driver.Navigate().GoToUrl(baseUrl);
            var quotes = driver.FindElements(By.CssSelector(".quote"));
            Assert.True(quotes.Count > 0);
        }
    }
}
