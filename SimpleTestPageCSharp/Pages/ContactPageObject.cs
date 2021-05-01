using OpenQA.Selenium;

namespace SimpleTestPageCSharp.Pages
{
    public class ContactPageObject
    {
        private IWebDriver _driver;
        public IWebElement Header => _driver.FindElement(By.ClassName("entry-header"));
        public IWebElement Content => _driver.FindElement(By.CssSelector("#post-3 > div > p:nth-child(1)"));

        public ContactPageObject(IWebDriver driver)
        {
            _driver = driver;
        }

        public string GetHeaderName()
        {
            return Header.Text;
        }
    }
}
