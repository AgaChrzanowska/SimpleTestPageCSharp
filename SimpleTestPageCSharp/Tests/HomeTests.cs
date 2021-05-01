using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SimpleTestPageCSharp.Common;
using SimpleTestPageCSharp.Pages;

namespace SimpleTestPageCSharp.Tests
{
    [TestClass]
    public class HomeTests

    {
        private IWebDriver _driver = new ChromeDriver();

        private StartPageObject _startPageObjectWithoutPageFactory => new StartPageObject(_driver);
        private MasterPageObject _menuPageObject => new MasterPageObject(_driver);

        [TestInitialize]
        public void SetUp()
        {
            _driver.Navigate().GoToUrl(Config.HOME_URL);

            var homeTabNumber = 1;
            _menuPageObject.SelectTopMenuItem(homeTabNumber);
        }

        [TestMethod]
        public void Posts_Count_Should_Be_10()
        {
            Assert.AreEqual(10, _startPageObjectWithoutPageFactory.GetPosts().GetPostsCount());
        }

        [TestCleanup]
        public void Cleanup()
        {
            _driver.Dispose();
        }
    }
}
