using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleTestPageCSharp.Models
{
    public class SocialMediaWebElements
    {
        public IWebElement FacebookWebElement { get; set; }
        public IWebElement LinkedinWebElement { get; set; }
        public IWebElement TweeterWebElement { get; set; }
        public IWebElement InstagramWebElement { get; set; }
    }
}
