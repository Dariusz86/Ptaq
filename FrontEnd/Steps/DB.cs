using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using BackEnd.Controllers;

namespace FrontEnd
{
    [Binding]
    public class Class1
    {
        [Then(@"example table (.*) has (.*) rows")]
        public void ThenExampleTablePerson_PersonHasRows(string tableName, int count)
        {
            DB_BasicController.GetCountFromGivenTable(tableName);
        }

    }
}
