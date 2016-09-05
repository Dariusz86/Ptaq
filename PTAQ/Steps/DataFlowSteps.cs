using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using BackEnd.SQL;
using NUnit.Framework;

namespace BackEnd.Steps
{
    [Binding]
    class DataFlowSteps
    {

        [Then(@"I compare Data using Except query")]
        public void ThenICompareDataUsingExceptQuery()
        {
            string query;
            Console.WriteLine("Except on Products");
            query = string.Format(ComparisonSqls.ExceptForProducts);
            Console.WriteLine(query);
            var count = ExecuteQuery.GetValueInt(query);            
            Console.WriteLine("There are {0} diffrences  in product tables !", count);
            Assert.AreEqual(0, count);
        }

        [Given(@"I verify Sums on (.*) for following source table (.*) and following target table (.*) using join on (.*) column")]
        [Then(@"I verify Sums on (.*) for following source table (.*) and following target table (.*) using join on (.*) column")]
        public void ThenIVerifySums(string columnForCompare, string sourceTable, string targetTable, string columnForJoinCondition)
        {
            string query;
            Console.WriteLine("Sums on particular columns");
            query = string.Format(ComparisonSqls.DiffsOnSums, columnForCompare, sourceTable, targetTable, columnForJoinCondition);
            Console.WriteLine(query);
            var diff = ExecuteQuery.GetStringValue(query);
            Console.WriteLine("Diffrence on sum is equal to: " + diff);
            Assert.AreEqual(Convert.ToDecimal(0), Convert.ToDecimal(diff));
        }

    }
}
