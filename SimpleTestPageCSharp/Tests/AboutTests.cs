using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SimpleTestPageCSharp.Common;
using SimpleTestPageCSharp.Pages;

namespace SimpleTestPageCSharp.Tests
{
    [TestClass]
    public class AboutTests
    {
        private IWebDriver _driver = new ChromeDriver();

        private AboutPageObject _aboutPageObject => new AboutPageObject(_driver);
        private MasterPageObject _masterPageObject => new MasterPageObject(_driver);

        [TestInitialize]
        public void SetUp()
        {
            _driver.Navigate().GoToUrl(Config.HOME_URL);

            var aboutTabNumber = 2;
           _masterPageObject.SelectTopMenuItem(aboutTabNumber);
        }

        [TestMethod]
        public void Schould_H1Title_Be_About()
        {
            Assert.AreEqual("About", _aboutPageObject.H1.Text);
        }

        [TestMethod]
        public void Box_Should_Exist()
        {
            Assert.IsNotNull(_aboutPageObject.Box);
        }

        [TestMethod]
        public void AddAnotherPage_Link_Should_Lead_To_New_Page()
        {
            var addPageLink = _aboutPageObject.GetAddAnotherPageLink();
            Assert.IsTrue(addPageLink.Contains("://wordpress.com/"));
        }

        [TestCleanup]
        public void Cleanup()
        {
            _driver.Dispose();
        }
    }
}
