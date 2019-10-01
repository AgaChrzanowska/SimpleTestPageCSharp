using System;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SimpleTestPageCSharp.Pages.Fragments;

namespace SimpleTestPageCSharp.Tests
{
    [TestClass]
    public class ContactFormTests
    {
        IWebDriver _driver = new ChromeDriver();
        ContactFormPageOject _contactFormPageOject;

        [TestInitialize]
        public void SetUp()
        {
            _driver.Navigate().GoToUrl("https://courseofautomationtesting.wordpress.com/contact/");
            _contactFormPageOject = new ContactFormPageOject(_driver);
        }

        [TestMethod]
        public void Check_If_Name_Is_Not_Null()
        {
            Assert.IsNotNull(_contactFormPageOject.GetName());
        }
        [TestMethod]
        public void Check_If_Form_Was_Submitted()
        {
            _contactFormPageOject.SubmitForm();
            Assert.AreEqual("Message Sent (go back)", _contactFormPageOject.GetMessageAfterSendForm());
        }

        [TestCleanup]
        public void Cleanup()
        {
            _driver.Dispose();
        }
    }
}
