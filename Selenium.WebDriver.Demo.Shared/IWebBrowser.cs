using OpenQA.Selenium;

namespace Selenium.WebDriver.Demo.Shared
{
    public interface IWebBrowser
    {
        void Click(IWebElement element);
        IWebElement FindElementById(string id);
        IWebElement FindElementByName(string name);
        void GotToUrl(string url);
        bool IsElementPresent(By by);
        void WriteTextOnInputBox(IWebElement element, string text);
    }
}