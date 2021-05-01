using OpenQA.Selenium;
using SimpleTestPageCSharp.Common;

namespace SimpleTestPageCSharp.Pages
{
    public class ContactFormPageOject
    {
        private IWebDriver _driver;
        public IWebElement NameInput => _driver.FindElement(By.Id("g3-name"));
        public IWebElement EmailInput => _driver.FindElement(By.Id("g3-email"));
        public IWebElement WebsiteInput => _driver.FindElement(By.Id("g3-website"));
        public IWebElement CommentInput => _driver.FindElement(By.Id("contact-form-comment-g3-comment"));
        public IWebElement SubmitBtn => _driver.FindElement(By.CssSelector("#contact-form-3 form p button"));
        public IWebElement SuccesfullMessage => _driver.FindElement(By.CssSelector("div#contact-form-3 h3"));
        public IWebElement Title => _driver.FindElement(By.ClassName("entry-title"));
        public IWebElement About => _driver.FindElement(By.CssSelector("#post-3 > div > p:nth-child(1)"));

        public ContactFormPageOject(IWebDriver driver)
        {
            _driver = driver;
        }

        public void FillAndSubmitForm(string name, string email, string website, string comment)
        {
            NameInput.SendKeys(name);
            EmailInput.SendKeys(email);
            WebsiteInput.SendKeys(website);
            CommentInput.SendKeys(comment);

            _driver.MoveToAndClick(SubmitBtn);
        }

        public string GetMessageAfterSubmitForm()
        {
            return SuccesfullMessage.Text;
        }
    }
}
