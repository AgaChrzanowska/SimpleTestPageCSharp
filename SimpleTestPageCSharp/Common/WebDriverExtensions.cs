using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;

namespace SimpleTestPageCSharp.Common
{
    public static class WebDriverExtensions
    {
        public static void MoveToAndClick(this IWebDriver driver, IWebElement webElement)
        {
            var actions = new Actions(driver);
            actions.MoveToElement(webElement).Click().Perform();
        }

        public static void WaitForElementWhenVisible(this IWebDriver driver, int seconds, By by)
        {
            WebDriverWait _wait = new WebDriverWait(driver, TimeSpan.FromSeconds(seconds));
            _wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(by));
        }
    }
}
