using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SimpleTestPageCSharp.Common;
using SimpleTestPageCSharp.Pages;

namespace SimpleTestPageCSharp.Tests
{
    [TestClass]
    public class MasterPageTests
    {
        private IWebDriver _driver = new ChromeDriver();

        private MasterPageObject _masterPageObject => new MasterPageObject(_driver);

        [TestInitialize]
        public void SetUp()
        {
            _driver.Navigate().GoToUrl(Config.HOME_URL);
        }

        [TestMethod]
        public void Menu_Should_Have_3_Items()
        {
            Assert.AreEqual(3, _masterPageObject.MenuItems.Count);
        }

        [TestMethod]
        public void Menu_Items_Should_Have_Proper_Names()
        {
            string[] menuItemsNames = _masterPageObject.GetMenuItemsNames();

            Assert.AreEqual("Home", menuItemsNames[0]);
            Assert.AreEqual("About", menuItemsNames[1]);
            Assert.AreEqual("Contact", menuItemsNames[2]);
        }

        [TestMethod]
        public void Site_Tittle_Text_Should_Be_Valid()
        {
            Assert.AreEqual("Site Title", _masterPageObject.GetSiteTitleText());
        }

        [TestMethod]
        public void SocialIcons_Count_Should_Be_4()
        {
            var socialMediaIconsCount = _masterPageObject.SocialMediaIcons.Count;
            Assert.AreEqual(4, socialMediaIconsCount);
        }

        [TestMethod]
        public void Facebook_Button_Should_Lead_To_Facebook_Page()
        {
            var fbLink = _masterPageObject.GetFacebookLink();
            Assert.IsTrue(fbLink.Contains("://www.facebook."));
        }

        [TestCleanup]
        public void Cleanup()
        {
            _driver.Dispose();
        }
    }
}