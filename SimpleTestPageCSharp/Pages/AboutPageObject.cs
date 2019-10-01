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
    public class AboutPageObject: IHaveTopMenu

    {
        private IWebDriver _driver;

        public IWebElement H1 { get; set; }
        public IWebElement Box { get; set; }
        public IWebElement AdvertPlace { get; set; }
        public IWebElement Footer { get; set; }

        public AboutPageObject(IWebDriver driver)
        {
            _driver = driver;
            H1 = _driver.FindElement(By.ClassName("entry-title"));
            Box = _driver.FindElement(By.ClassName("entry-content"));
            AdvertPlace = _driver.FindElement(By.ClassName("wpcnt"));
            Footer = _driver.FindElement(By.Id("colophon"));
        }

        public string GetH1Title()
        {
            return H1.Text;
        }

        public string GetAdvertText()
        {
            return AdvertPlace.Text;
        }

        public string GetFooterText()
        {
            return Footer.Text;
        }

        public TopMenuPageObject GetTopMenuPageObject()
        {
            return new TopMenuPageObject(_driver);
        }

        //public int[] GetH1Lenght()
        //{
        //    return new int[]
        //    {

        //    };
        //}
    }
}
