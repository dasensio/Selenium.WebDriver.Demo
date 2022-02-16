using Selenium.WebDriver.Demo.Chrome;
using Selenium.WebDriver.Demo.GoogleSearch;

GoogleSearch google = new GoogleSearch(new Chrome(30));
google.Load();
google.AcceptCookies();
google.SearchFor("bravent");
google.ExecuteSearch();
google.ClickOnFirstResult();