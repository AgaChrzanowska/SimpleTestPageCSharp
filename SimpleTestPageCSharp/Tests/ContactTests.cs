﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SimpleTestPageCSharp.Common;
using SimpleTestPageCSharp.Pages;

namespace SimpleTestPageCSharp.Tests
{
    [TestClass]
    public class ContactTests
    {
        private IWebDriver _driver = new ChromeDriver();

        private ContactPageObject _contactPageObject => new ContactPageObject(_driver);
        private MasterPageObject _masterPageObject => new MasterPageObject(_driver);


        [TestInitialize]
        public void SetUp()
        {
            _driver.Navigate().GoToUrl(Config.HOME_URL);

            var contactTabNumber = 3;
            _masterPageObject.SelectTopMenuItem(contactTabNumber);
        }

        [TestMethod]
        public void HeaderName_Should_Be_Contact()
        {
            Assert.AreEqual("Contact", _contactPageObject.GetHeaderName());
        }

        [TestCleanup]
        public void Cleanup()
        {
            _driver.Dispose();
        }
    }
}
