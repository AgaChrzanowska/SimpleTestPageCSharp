using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SimpleTestPageCSharp.Pages;

namespace SimpleTestPageCSharp.Tests
{
    [TestClass]
    public class StartTests

    {
        IWebDriver _driver = new ChromeDriver();
        StartPageObject _startPageObjectWithoutPageFactory;
        //TopMenuPageObject _topMenuPageObject;

        [TestInitialize]
        public void SetUp()
        {
            _driver.Navigate().GoToUrl("https://courseofautomationtesting.wordpress.com/");
            _startPageObjectWithoutPageFactory = new StartPageObject(_driver);
            //_topMenuPageObject = _startPageObjectWithoutPageFactory.GetTopMenuPageObject();
        }

        [TestMethod]
        public void Check_H1_Text()
        {
            Assert.AreEqual("Site Title", _startPageObjectWithoutPageFactory.H1.Text);
        }

        [TestMethod]
        public void Check_SocialList_Count()
        {
            Assert.AreEqual(4, _startPageObjectWithoutPageFactory.GetSocialListNumber());
        }
        [TestMethod]
        public void CheckFacebookLinkName()
        {
            Assert.AreEqual("http://www.facebook.com/", _startPageObjectWithoutPageFactory.GetFacebookLink());
        }

        [TestMethod]
        public void Check_Posts_Count()
        {
            Assert.AreEqual(7, _startPageObjectWithoutPageFactory.GetPosts().GetPostsCount());
        }


        [TestCleanup]
        public void Cleanup()
        {
            _driver.Dispose();
        }
    }
}
