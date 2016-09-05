using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;


namespace FrontEnd.SetUp
{
    [Binding]
    class InitializeSeleniumTest
    {
        [BeforeScenario]
        public void Setup()
        {
            //Driver.Initialize();
        }
    }
}
