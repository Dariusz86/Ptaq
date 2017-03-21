using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;


namespace FrontEnd.Hooks
{
    [Binding]
    class BeforeAndAfterTest
    {
        // SpecFlow hooks
        // Can be used for example for opening DB connection
        // Before specific category of tests

      
        [BeforeScenario]
        public void Setup()
        {
            //Driver.Initialize();
        }

        [BeforeScenario("mytag")]
        public static void BeforeScenario()
        {
            //ExecuteQuery.OpenConnection("Default");
        }

        [AfterTestRun]
        public static void AfterTest()
        {
            //ExecuteQuery.CloseConnection();
        }
    }
}
