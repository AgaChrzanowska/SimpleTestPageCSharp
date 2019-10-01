using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SimpleTestPageCSharp.Models;
using SimpleTestPageCSharp.Pages;
using SimpleTestPageCSharp.Pages.Fragments;

namespace SimpleTestPageCSharp.Tests
{
    [TestClass]
    public class PostsTests
    {
        IWebDriver _driver = new ChromeDriver();
        PostsPageObject _postsPageObject;

        [TestInitialize]
        public void SetUp()
        {
            _driver.Navigate().GoToUrl("https://courseofautomationtesting.wordpress.com/");
            _postsPageObject = new PostsPageObject(_driver);
        }

        [TestMethod]
        public void Schould_PostsCount_Be_7()
        {
            PostModel pm = _postsPageObject.GetPostModelByIndex(0);
            Assert.AreEqual(7, _postsPageObject.GetPostsCount());
        }

        [TestMethod]
        public void Schould_FirstPostName_Be_Test()
        {
            // TODO:   wrong assertion 
            Assert.AreEqual("Test", _postsPageObject.GetPostModelByIndex(0).Title); 
        }

        [TestMethod]
        public void CheckTitle_FirstPost()
        {
            Assert.AreEqual("Test", _postsPageObject.GetPostModelByIndex(0).Title);
        }
        [TestMethod]
        public void Schould_Author_AllPosts_Be_Learnautomation()
        {
            List<PostModel> allPosts = _postsPageObject.GetAllPostModels();

            Predicate<PostModel> predicate = post => post.Author == "learnautomationn";

            bool hasTheSamePosterName = allPosts.TrueForAll(predicate);

            bool sss = allPosts.Exists(p => p.Content.StartsWith("A"));

            Assert.AreEqual(true, hasTheSamePosterName);
        }

        [TestMethod]
        public void Check_Content_First_Post()
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
