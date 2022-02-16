using OpenQA.Selenium;
using Selenium.WebDriver.Demo.Shared;

namespace Selenium.WebDriver.Demo.GoogleSearch
{
    public class GoogleSearch
    {
        private readonly IWebBrowser _browser;
        private readonly string _baseUrl;

        public GoogleSearch(IWebBrowser browser)
        {
            _browser = browser;
            _baseUrl = "https://www.google.es";
        }

        public void Load()
        {
            _browser.GotToUrl(_baseUrl);
        }

        public void AcceptCookies()
        {
            if (_browser.IsElementPresent(By.Id("L2AGLb")))
            {
                _browser.Click(_browser.FindElementById("L2AGLb"));
            }
        }

        public void SearchFor(string textToSearch)
        {
            _browser.WriteTextOnInputBox(_browser.FindElementByName("q"), textToSearch);
        }

        public void ExecuteSearch()
        {
            _browser.WriteTextOnInputBox(_browser.FindElementByName("q"), Keys.Enter);
        }

        public void ClickOnFirstResult()
        {
            IWebElement results = _browser.FindElementById("rso");
            results.FindElement(By.TagName("a")).Click();
        }
    }
}