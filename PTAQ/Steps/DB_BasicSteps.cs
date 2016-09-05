using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using NUnit.Framework;
using BackEnd.Controllers;

namespace BackEnd.Steps
{
    [Binding]
    class DB_BasicSteps
    {
        [Given(@"table (.*) has (.*) rows")]
        [When(@"table (.*) has (.*) rows")]
        [Then(@"table (.*) has (.*) rows")]
        public void TakeCountOfRows(string table, int countExpected)
        {
            Console.Write("Check Counts");
            int countActual = DB_BasicController.GetCountFromGivenTable(table);
            Assert.AreEqual(countExpected, countActual); 
        }


        [When(@"following row is present: (.*) in following table (.*) with amount of (.*)")]
        [Then(@"following row is present: (.*) in following table (.*) with amount of (.*)")]
        [When(@"following row is present: (.*) in following view (.*) with amount of (.*)")]
        [Then(@"following row is present: (.*) in following view (.*) with amount of (.*)")]
        public void VerifyParticularRow(string condition, string tableName, int countExpected)
        {
            Console.WriteLine("Verification of particular row");
            Console.WriteLine("Condition: {0}, Table: {1}", condition, tableName);
            int countActual = DB_BasicController.GetCountFromGivenTableWithCondition(tableName, condition);
            Assert.AreEqual(countActual, countExpected);
        }


        [Given(@"I run SQL query from (.*)")]
        public void GivenIRunSQLQueryFromCreateTestTable_Sql(string fileName)
        {
            Console.WriteLine("Will run SQL query from following file: {0}", fileName);
            DB_BasicController.ExecuteQueryFromFile(fileName);
        }

    }
}
