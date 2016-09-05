using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using BackEnd.SQL;

namespace BackEnd.SetUp
{
    [Binding]
    class OpenConnection
    {
        [BeforeScenario("mytag")]
        public static void BeforeScenario()
        {
            ExecuteQuery.OpenConnection("Default");
        }

        [AfterTestRun]
        public static void AfterTest()
        {
            ExecuteQuery.CloseConnection();
        }
    }
}
