using OpenQA.Selenium;
using SimpleTestPageCSharp.Models;
using System.Collections.Generic;
using System.Linq;

namespace SimpleTestPageCSharp.Pages
{
    public class PostsPageObject
    {
        public IWebDriver _driver;
        public IList<IWebElement> Posts => _driver.FindElements(By.CssSelector("div#primary main.site-main article"));

        private List<PostModel> _postModels = new List<PostModel>();

        public PostsPageObject(IWebDriver driver)
        {
            _driver = driver;
            InitPostModel();
        }

        private void InitPostModel()
        {

            for (int i = 0; i < Posts.Count; i++)
            {
                var post = Posts.ElementAt(i);
                var postModel = new PostModel();

                postModel.Title = post.FindElement(By.CssSelector("header h1 a")).Text;
                postModel.Content = post.FindElement(By.CssSelector("div p")).Text;
                postModel.Author = post.FindElement(By.CssSelector("footer div span.byline")).Text;
                postModel.TagsCategory = post.FindElement(By.CssSelector("footer div span.cat-links")).Text;
                postModel.Comments = post.FindElement(By.CssSelector("footer div span.comments-link")).Text;
                postModel.Date = post.FindElement(By.CssSelector("footer div span.published-on")).Text;
                postModel.TimeToRead = post.FindElement(By.CssSelector("footer div span.word-count")).Text;

                _postModels.Add(postModel);
            }
        }

        public int GetPostsCount()
        {
            return Posts.Count();
        }

        public PostModel GetPostModelByIndex(int index)
        {
            return _postModels.ElementAt(index);
        }

        public List<PostModel> GetAllPostModels()
        {
            return _postModels;
        }
    }
}
