using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using Selenium.WebDriver.Demo.Shared;

namespace Selenium.WebDriver.Demo.Chrome
{
    public class Chrome : IWebBrowser
    {
        private readonly ChromeDriver _driver;
        private int _timeoutSeconds;

        public ChromeDriver Driver => _driver;

        public Chrome(int timeoutSeconds = 60)
        {
            _driver = InitializeDriver(new ChromeOptions(), timeoutSeconds);
        }

        public void Click(IWebElement element)
        {
            element.Click();
        }

        public IWebElement FindElementById(string id)
        {
            ValidateDriver();

            return new WebDriverWait(Driver, TimeSpan.FromSeconds(_timeoutSeconds)).Until(e => e.FindElement(By.Id(id)));
        }

        public IWebElement FindElementByName(string name)
        {
            ValidateDriver();

            return new WebDriverWait(Driver, TimeSpan.FromSeconds(_timeoutSeconds)).Until(e => e.FindElement(By.Name(name)));
        }

        public void GotToUrl(string url)
        {
            ValidateDriver();

            Driver.Navigate().GoToUrl(url);
        }

        public bool IsElementPresent(By by)
        {
            ValidateDriver();

            return new WebDriverWait(Driver, TimeSpan.FromSeconds(_timeoutSeconds)).Until(e => e.FindElement(by).Displayed);
        }

        public void WriteTextOnInputBox(IWebElement element, string text)
        {
            element.SendKeys(text);
        }

        private void ValidateDriver()
        {
            if (Driver == null)
            {
                throw new Exception("Driver is null");
            }
        }

        private ChromeDriver InitializeDriver(ChromeOptions options, int timeoutSeconds = 60)
        {
            _timeoutSeconds = timeoutSeconds;
            ChromeDriver driver = new ChromeDriver(options);
            SetDriverTimeouts(driver, timeoutSeconds);

            return driver;
        }

        private void SetDriverTimeouts(ChromeDriver driver, int timeoutSeconds)
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(timeoutSeconds);
        }
    }
}