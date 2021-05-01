using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace SimpleTestPageCSharp.Pages
{
    public class AboutPageObject
    {
        private IWebDriver _driver;

        public IWebElement H1 => _driver.FindElement(By.ClassName("entry-title"));
        public IWebElement Box => _driver.FindElement(By.ClassName("entry-content"));
        public IWebElement Footer => _driver.FindElement(By.Id("colophon"));
        public IWebElement AddLink => _driver.FindElement(By.CssSelector("div.entry-content>p>a"));

        public AboutPageObject(IWebDriver driver)
        {
            _driver = driver;
        }
       
        public string GetAddAnotherPageLink()
        {
            return AddLink.GetAttribute("href");
        }
    }
}
