using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace FrontEnd
{
    public static class Driver
    {
        //public static IWebDriver Instance { get; set; }

        public static IWebDriver Initialize()
        {
            Console.WriteLine("Test");
            ChromeDriver Instance = new ChromeDriver();
            Instance.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));
            Instance.Manage().Window.Maximize();
            //Instance.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));
            //Instance.Navigate().GoToUrl("http://www.wp.pl");
            return Instance;
        }
    }
}
