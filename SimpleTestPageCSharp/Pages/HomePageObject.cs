using OpenQA.Selenium;

namespace SimpleTestPageCSharp.Pages
{
    public class StartPageObject
    {
        private IWebDriver _driver;
        
        public StartPageObject(IWebDriver driver)
        {
            _driver = driver;
        }

        public PostsPageObject GetPosts()
        {
            return new PostsPageObject(_driver);
        }
    }
}
