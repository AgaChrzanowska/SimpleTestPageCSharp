using OpenQA.Selenium;

namespace SimpleTestPageCSharp.Pages
{
    public class SocialMediaPageObject
    {
        private IWebDriver _driver;
        public IWebElement FacebookLink => _driver.FindElement(By.CssSelector("ul#menu-social-media li:nth-child(1) a"));
        public IWebElement LinkedinLink => _driver.FindElement(By.CssSelector("ul#menu-social-media li:nth-child(2) a"));
        public IWebElement TweeterLink => _driver.FindElement(By.CssSelector("ul#menu-social-media li:nth-child(3) a"));
        public IWebElement InstagramLink => _driver.FindElement(By.CssSelector("ul#menu-social-media li:nth-child(4) a"));

        public SocialMediaPageObject(IWebDriver driver)
        {
            _driver = driver;
        }
    }
}
