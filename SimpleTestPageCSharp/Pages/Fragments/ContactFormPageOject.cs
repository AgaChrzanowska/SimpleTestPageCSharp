using OpenQA.Selenium;
using SimpleTestPageCSharp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SimpleTestPageCSharp.Pages.Fragments
{
   public class ContactFormPageOject
    {
        private IWebDriver _driver { get; set; }
        public IList<IWebElement> ContactFormInputs { get; set; }
        public IList<IWebElement> ContactFormLabels { get; set; }
        public IWebElement SuccesfullMessage { get; set; }


        public ContactFormPageOject(IWebDriver driver)
        {
            _driver = driver;
            ContactFormInputs = _driver.FindElements(By.CssSelector("#contact-form-3 form div input, textarea, button.pushbutton-wide"));
            ContactFormLabels = _driver.FindElements(By.CssSelector("#contact-form-3 form div label"));
           
            FillForm();
        }

        private void FillForm()
        {
            ContactFormInputs.ElementAt(0).SendKeys("Maria");
            ContactFormInputs.ElementAt(1).SendKeys("mary@op.pl");
            ContactFormInputs.ElementAt(2).SendKeys("https://courseofautomationtesting.wordpress.com/contact/");
            ContactFormInputs.ElementAt(3).SendKeys("This is test page");
        }
        public void SubmitForm()
        {
            ContactFormInputs.ElementAt(4).Click();
            Thread.Sleep(500);
            SuccesfullMessage = _driver.FindElement(By.CssSelector("div#contact-form-3 h3"));
        }

        public string GetName()
        {
            return ContactFormInputs.ElementAt(0).Text;
        }
        public string GetEmail()
        {
            return ContactFormInputs.ElementAt(1).Text;
        }
        public string GetUrl()
        {
            return ContactFormInputs.ElementAt(2).Text;
        }
        public string GetComment()
        {
            return ContactFormInputs.ElementAt(3).Text;
        }
        public string GetMessageAfterSendForm()
        {
            return SuccesfullMessage.Text;
        }
    }
}
