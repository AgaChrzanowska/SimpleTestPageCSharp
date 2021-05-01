using OpenQA.Selenium;
using System.Collections.Generic;
using System.Linq;

namespace SimpleTestPageCSharp.Pages
{
    public class MasterPageObject
    {
        private IWebDriver _driver;
        public IWebElement SiteTitle => _driver.FindElement(By.CssSelector(".site-title a"));
        public IList<IWebElement> MenuItems => _driver.FindElements(By.CssSelector("ul#primary-menu li"));
        public IList<IWebElement> SocialMediaIcons => _driver.FindElements(By.CssSelector("ul#menu-social-media li a"));

        /// <summary>
        /// This element exists in iframe, so WebDriver need to be switched on to relevant context first.
        /// </summary>
        public IWebElement AcceptCookiesBtn => _driver.FindElement(By.CssSelector("div.frame-content .components-button.is-primary"));

        private SocialMediaPageObject _socialMediaWebElements => new SocialMediaPageObject(_driver);

        public MasterPageObject(IWebDriver driver)
        {
            _driver = driver;
        }

        public string GetSiteTitleText()
        {
            return SiteTitle.Text;
        }

        public string[] GetMenuItemsNames()
        {
            return new string[]
            {
               MenuItems.ElementAt(0).Text, MenuItems.ElementAt(1).Text, MenuItems.ElementAt(2).Text
            };
        }

        public void SelectTopMenuItem(int itemNumber)
        {
            var itemLink = _driver.FindElement(By.CssSelector($".menu-primary-container li:nth-child({itemNumber}) a"));
            itemLink.Click();
        }

        public string GetFacebookLink()
        {
            return _socialMediaWebElements.FacebookLink.GetAttribute("href");
        }
    }
}
