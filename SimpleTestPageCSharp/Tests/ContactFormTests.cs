using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SimpleTestPageCSharp.Common;
using SimpleTestPageCSharp.Pages;

namespace SimpleTestPageCSharp.Tests
{
    [TestClass]
    public class ContactFormTests
    {
        private IWebDriver _driver = new ChromeDriver();

        private ContactFormPageOject _contactFormPageOject => new ContactFormPageOject(_driver);
        private MasterPageObject _masterPageObject => new MasterPageObject(_driver);

        [TestInitialize]
        public void SetUp()
        {
            _driver.Navigate().GoToUrl(Config.HOME_URL);

            var contactTabNumber = 3;
            _masterPageObject.SelectTopMenuItem(contactTabNumber);

            _driver.SwitchTo().Frame(1);
            _masterPageObject.AcceptCookiesBtn.Click();
            _driver.SwitchTo().DefaultContent();

        }

        [TestMethod]
        public void Submitted_Form_Should_Show_Confirmation_Message()
        {
            _contactFormPageOject.FillAndSubmitForm(
                name: DataHelper.GetRandomText(8),
                email: string.Format($"{DataHelper.GetRandomText(8)}@gmail.com"),
                website: "https://wp.pl",
                comment: DataHelper.GetRandomText(15));

            _driver.WaitForElementWhenVisible(2, By.CssSelector("div#contact-form-3 h3"));

            Assert.AreEqual("Message Sent (go back)", _contactFormPageOject.GetMessageAfterSubmitForm());
        }

        [TestMethod]
        public void Contact_Page_Should_Have_Proper_Name()
        {
            Assert.AreEqual("Contact", _contactFormPageOject.Title.Text);
        }

        [TestMethod]
        public void About_Decsription_Should_Be_Valid()
        {
            Assert.AreEqual("This is a contact page with some basic contact information and a contact form.", 
                _contactFormPageOject.About.Text);
        }

        [TestCleanup]
        public void Cleanup()
        {
            _driver.Dispose();
        }
    }
}
