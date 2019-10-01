using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleTestPageCSharp.Pages.Fragments

{
    public class TopMenuPageObject
    {
        private IWebDriver _driver;
        public IList<IWebElement> MenuItems { get; set; }

        public TopMenuPageObject(IWebDriver driver)
        {
            _driver = driver;

            MenuItems = _driver.FindElements(By.CssSelector("ul#primary-menu li"));

        }

        public int GetMenuItemsCount()
        {
            return MenuItems.Count();
        }

        public string[] GetMenuItemsNames()
        {
            return new string[]
            {
               MenuItems.ElementAt(0).Text, MenuItems.ElementAt(1).Text, MenuItems.ElementAt(2).Text
            };
        }
    }
}
