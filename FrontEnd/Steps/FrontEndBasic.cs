using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using OpenQA.Selenium;

namespace FrontEnd.Steps
{
    [Binding]
    class FrontEndBasic
    {
        [Given(@"I run Chrome browser and go to (.*)")]
        public void GoToPage (string page)
        {
            IWebDriver WebInstance = Driver.Initialize();
            WebInstance.Navigate().GoToUrl(page);
            WebInstance.FindElements(By.XPath("test"));
        }

    }
}
