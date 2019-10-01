using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SimpleTestPageCSharp.Pages;

namespace SimpleTestPageCSharp.Tests
{
    [TestClass]
    public class ContactTests
    {
        IWebDriver _driver = new ChromeDriver();
        ContactPageObject _contactPageObject;

        [TestInitialize]
        public void SetUp()
        {
            _driver.Navigate().GoToUrl("https://courseofautomationtesting.wordpress.com/contact/");
            _contactPageObject = new ContactPageObject(_driver);
        }


        [TestMethod]
        public void Schould_HeaderName_Be_Contact()
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
