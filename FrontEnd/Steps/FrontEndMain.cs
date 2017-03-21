using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using FrontEnd.Pages;
using TechTalk.SpecFlow;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace FrontEnd.Main
{
    [Binding]
    class FrontEndMain
    {

        public IWebDriver Driver { get; set; }

        [Given(@"I start Chrome browser")]
        public void GivenIStartChromeBrowser()
        {
            this.Driver = new ChromeDriver("C:\\PTAQ\\Repo-2016_09\\Ptaq\\FrontEnd\\");
        }

        [Then(@"I close browser")]
        public void ThenICloseBrowser()
        {
            Thread.Sleep(5000);
            this.Driver.Quit();
        }

        [When(@"I navigate to (.*)")]
        public void WhenINavigateToPage(string url)
        {
            this.Driver.Navigate().GoToUrl(url);
        }

        [When(@"I verify existence of elements on page")]
        public void VerifyExistenceOfElementsOnPage()
        {
            
        }

        [When(@"I fill the form")]
        public void WhenIFillTheForm()
        {
            Thread.Sleep(1000);
            TableListPage tableListPage = new TableListPage(this.Driver);
            tableListPage.FillInvestmentClickDeclareInvestemnt();
            tableListPage.FillFormWithTestData();
        }


    }
}
