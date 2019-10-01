using OpenQA.Selenium;
using SimpleTestPageCSharp.Abtracts;
using SimpleTestPageCSharp.Pages.Fragments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleTestPageCSharp.Pages
{
    class ContactPageObject: IHaveTopMenu
    {
        private IWebDriver _driver { get; set; }
        public IWebElement Header { get; set; }
        public IWebElement Content { get; set; }

        public ContactPageObject(IWebDriver driver)
        {
            _driver = driver;
            Header = _driver.FindElement(By.ClassName("entry-header"));
            Content = _driver.FindElement(By.CssSelector("#post-3 > div > p:nth-child(1)"));

        }

        public string GetHeaderName()
        {
            return Header.Text;
        }

        public TopMenuPageObject GetTopMenuPageObject()
        {
            return new TopMenuPageObject(_driver);
        }
    }
}
