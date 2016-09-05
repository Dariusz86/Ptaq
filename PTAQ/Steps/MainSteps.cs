using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace BackEnd.Steps
{
    [Binding]
    class MainSteps
    {
        [Given(@"I run query: (.*)")]
        public void GivenIRunQueryInsertIntoHumanResources_DepartmentValues(string query)
        {
            Console.WriteLine("tescik " + query);
        }

    }
}
