using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;


namespace FrontEnd.Pages
{
    public class TableListPage
    {
        private readonly IWebDriver driver;
        public TableListPage(IWebDriver browser)
        {
            this.driver = browser;
            PageFactory.InitElements(browser, this);
        }



        [FindsBy(How = How.XPath, Using = "//input[@type='button']")]
        public IWebElement DeclareInvestmentButton { get; set; }

        [FindsBy(How = How.Name, Using = "name")]
        public IWebElement NameTexEdit { get; set; }

        [FindsBy(How = How.Name, Using = "lastName")]
        public IWebElement LastNameTexEdit { get; set; }

        [FindsBy(How = How.Name, Using = "ActiveInvestmentsTotalNumber")]
        public IWebElement ActiveInvestmentsTotalNumber { get; set; }

        [FindsBy(How = How.Name, Using = "ActiveInvestmentsTotalAmount")]
        public IWebElement ActiveInvestmentsTotalAmount { get; set; }

        [FindsBy(How = How.Name, Using = "ActiveInvestmentMaxValue")]
        public IWebElement ActiveInvestmentMaxValue { get; set; }

        [FindsBy(How = How.Id, Using = "fileToUpload")]
        public IWebElement FileToUpload { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@type='submit']")]
        public IWebElement SubmitButton { get; set; }



        //*[@id="main"]/div/div/div/table/tbody/tr[1]/td/input
        //By.XPath("//button[@type='submit']")

        //Boolean isPresent = driver.findElements(By.yourLocator).size() > 0

        //WebElement element = driver.findElement(By.id(“UserName“));
        //web declareInvestmentButton = new WebElement();
        //    = this.driver.FindElement(By.XPath("//button[@type='submit']")).Click();
        //public By oddsButton = driver.findElement(By.id("UserName"));


        public void FillInvestmentClickDeclareInvestemnt()
        {
            DeclareInvestmentButton.Click();
        }

        public void FillFormWithTestData()
        {
            string name = "Dariusz";
            string lastName= "Szudrzyński";

            Console.WriteLine("Filling form with name: " + name);
            NameTexEdit.SendKeys("Dariusz");
            Console.WriteLine("Filling for with lastname: " + lastName);
            LastNameTexEdit.SendKeys("Szudrzynski");

            ActiveInvestmentsTotalNumber.SendKeys("10");
            ActiveInvestmentsTotalAmount.SendKeys("200");
            ActiveInvestmentMaxValue.SendKeys("75");

            FileToUpload.Click();
            FileToUpload.SendKeys("C:\\Users\\e-dzsi\\Desktop\\Example123.csv");

            SubmitButton.Click();
        }
    }
}
