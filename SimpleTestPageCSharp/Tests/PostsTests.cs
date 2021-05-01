using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SimpleTestPageCSharp.Common;
using SimpleTestPageCSharp.Models;
using SimpleTestPageCSharp.Pages;

namespace SimpleTestPageCSharp.Tests
{
    [TestClass]
    public class PostsTests
    {
        private IWebDriver _driver = new ChromeDriver();

        private PostsPageObject _postsPageObject => new PostsPageObject(_driver);
        private MasterPageObject _masterPageObject => new MasterPageObject(_driver);

        [TestInitialize]
        public void SetUp()
        {
            _driver.Navigate().GoToUrl(Config.HOME_URL);

            var homeTabNumber = 1;
            _masterPageObject.SelectTopMenuItem(homeTabNumber);
        }

        [TestMethod]
        public void FIrst_Post_Name_Should_Be_Valid()
        {
            Assert.AreEqual("Test", _postsPageObject.GetPostModelByIndex(0).Title);
        }

        [TestMethod]
        public void All_Posts_Author_Name_Should_Be_Learnautomation()
        {
            var allPosts = _postsPageObject.GetAllPostModels();
            Predicate<PostModel> predicate = post => post.Author == "learnautomationn";
            var hasTheSamePosterName = allPosts.TrueForAll(predicate);

            Assert.AreEqual(true, hasTheSamePosterName);
        }

        [TestMethod]
        public void First_Post_Content_Should_Be_Valid()
        {
            Assert.AreEqual("New post", _postsPageObject.GetPostModelByIndex(0).Content);
        }

        [TestCleanup]
        public void Cleanup()
        {
            _driver.Dispose();
        }
    }
}
