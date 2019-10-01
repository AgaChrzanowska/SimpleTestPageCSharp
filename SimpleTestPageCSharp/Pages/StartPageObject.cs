using OpenQA.Selenium;
using SimpleTestPageCSharp.Abtracts;
using SimpleTestPageCSharp.Models;
using SimpleTestPageCSharp.Pages.Fragments;
using System.Collections.Generic;
using System.Linq;

namespace SimpleTestPageCSharp.Pages
{
    public class StartPageObject : IHaveTopMenu, IHavePosts
    {
        private IWebDriver _driver { get; set; }
        public IWebElement H1 { get; set; }
        public IList<IWebElement> SocialList { get; set; }
        private SocialMediaWebElements _socialMediaWebElements;
        private TopMenuPageObject _topMenuPageObject;

        public StartPageObject(IWebDriver driver)
        {
            _driver = driver;
            H1 = _driver.FindElement(By.ClassName("site-title"));
            SocialList = _driver.FindElements(By.CssSelector("ul#menu-social-media li a"));
            _topMenuPageObject = new TopMenuPageObject(_driver);

            InitSocialMediaModel();
        }

        private void InitSocialMediaModel()
        {
            _socialMediaWebElements = new SocialMediaWebElements();
            _socialMediaWebElements.FacebookWebElement = SocialList.ElementAt(0);
            _socialMediaWebElements.LinkedinWebElement = SocialList.ElementAt(1);
            _socialMediaWebElements.TweeterWebElement = SocialList.ElementAt(2);
            _socialMediaWebElements.InstagramWebElement = SocialList.ElementAt(3);
        }


        public int GetSocialListNumber()
        {
            return SocialList.Count();
        }

        public string GetFacebookLink()
        {
            return _socialMediaWebElements.FacebookWebElement.GetAttribute("href");
        }

        public IWebDriver GetDriver()
        {
            return _driver;
        }

        public TopMenuPageObject GetTopMenuPageObject()
        {
            return _topMenuPageObject;
        }

        public PostsPageObject GetPosts()
        {
            return new PostsPageObject(_driver);
        }
    }
}
