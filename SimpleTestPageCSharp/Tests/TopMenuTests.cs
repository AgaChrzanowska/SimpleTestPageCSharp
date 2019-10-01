using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SimpleTestPageCSharp.Pages;
using SimpleTestPageCSharp.Pages.Fragments;

namespace SimpleTestPageCSharp.Tests
{
    [TestClass]
    public class TopMenuTests
    {
        IWebDriver _driver = new ChromeDriver();
        TopMenuPageObject _topMenuPageObject;

        [TestInitialize]
        public void SetUp()
        {
            _driver.Navigate().GoToUrl("https://courseofautomationtesting.wordpress.com/");
            _topMenuPageObject = new TopMenuPageObject(_driver);
        }


        [TestMethod]
        public void Should_TopMenuItemsCount_Be_3()
        {
            Assert.AreEqual(3, _topMenuPageObject.GetMenuItemsCount());
        }

        [TestMethod]
        public void Should_TopMenu_Has_Proper_Names()
        {
            string[] menuItemsNames = _topMenuPageObject.GetMenuItemsNames();
            
            Assert.AreEqual("Home", menuItemsNames[0]);
            Assert.AreEqual("About", menuItemsNames[1]);
            Assert.AreEqual("Contact", menuItemsNames[2]);
        }
       

        [TestCleanup]
        public void Cleanup()
        {
            _driver.Dispose();
        }
    }
}