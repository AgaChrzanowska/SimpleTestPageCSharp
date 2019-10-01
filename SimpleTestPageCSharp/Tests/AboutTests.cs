using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SimpleTestPageCSharp.Pages;

namespace SimpleTestPageCSharp.Tests
{
    [TestClass]
    public class AboutTests
    {
        IWebDriver _driver = new ChromeDriver();
        AboutPageObject _aboutPageObject;

        [TestInitialize]
        public void SetUp()
        {
            _driver.Navigate().GoToUrl("https://courseofautomationtesting.wordpress.com/about/");
            _aboutPageObject = new AboutPageObject(_driver);
        }

        [TestMethod]
        public void Schould_H1Title_Be_About()
        {
            Assert.AreEqual("About", _aboutPageObject.GetH1Title());
        }

        [TestMethod]
        public void Schould_Box_Exist()
        {
            Assert.IsNotNull(_aboutPageObject.Box);
        }

        [TestMethod]
        public void Check_AdvertPlace_Exist()
        {
            Assert.IsTrue(_aboutPageObject.GetAdvertText().StartsWith("Advertisements"));
        }

        [TestMethod]
        public void Check_Footer_Text()
        {
            Assert.AreEqual("Create a free website or blog at WordPress.com.", _aboutPageObject.GetFooterText());
        }

        [TestCleanup]
        public void Cleanup()
        {
            _driver.Dispose();
        }
    }
}
