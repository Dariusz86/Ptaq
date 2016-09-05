using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BackEnd.SQL;
using Tools;

namespace BackEnd.Controllers
{
    class ComparisonController
    {
        public static void ExecuteQueryForHumanResources(string JobTitle, string BirthDate)
        {
            string query = String.Format(ComparisonSqls.CountFromGivenTable, JobTitle, BirthDate);
            Console.WriteLine(query);
            Console.WriteLine(JobTitle);
            Console.WriteLine(BirthDate);
            ExecuteQuery.WriteQueryResultToFile(query, CMD.CMDTargetFolderPath + "\\" + CMD.CurrentFileName);
            Console.WriteLine("PATH " + CMD.CMDTargetFolderPath + "\\" + CMD.CurrentFileName);
        }

        //public static void WriteQueryToFile()

    }
}
