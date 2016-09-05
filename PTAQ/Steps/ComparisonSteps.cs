using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using BackEnd.Controllers;
using BackEnd.SQL;
using Tools;
using NUnit.Framework;

namespace BackEnd.Steps
{
    [Binding]
    class ComparisonSteps
    {

        [When(@"I write results from (.*) into CSV file")]
        [Then(@"I write results from (.*) into CSV file")]
        public void ThenIWriteResultsFromTableIntoCSVFile(string tableName)
        {
            string query = String.Format(ComparisonSqls.Products, tableName);
            Console.WriteLine("PATH " + CMD.CMDTargetFolderPath + "\\" + CMD.CurrentFileName + ".csv");
            ExecuteQuery.WriteQueryResultToFile(query, CMD.CMDTargetFolderPath + "\\" + CMD.CurrentFileName + ".csv");
        }


        [Then(@"I store all logins for (.*) and (.*) which are male")]
        public void ThenIStoreAllLoginsForSeniorToolDesignerAndWhichAreMale(string JobTitle, string BirthDate)
        {
            ComparisonController.ExecuteQueryForHumanResources(JobTitle, BirthDate);                       
        }


        [Then(@"I write results from file into (.*) table")]
        public void ThenIWriteResultsFromFileIntoQa_HRTableTable(string table)
        {
            ExecuteQuery.UploadDataFromFile(CMD.CMDTargetFolderPath + "\\" + CMD.CurrentFileName + ".csv", table);
        }


        [Then(@"I write results from (.*) into ExcelFile")]
        public void ThenIWriteResultsFromFileIntoIntoExcelFileUsingExampleQuery( string tableName)
        {
            string query = String.Format(ComparisonSqls.Products, tableName);
            var data = ExecuteQuery.GetExplicitReults(query);
            Console.WriteLine("Query: " + query);
            ExcelWriter.WriteDataTableToXLS(data, CMD.CMDTargetFolderPath + "\\" + CMD.CurrentFileName);
        }


        [Then(@"I use xls to compare (.*) with (.*)")]
        public void ThenCompareFilesUsingXLS(string filename1, string filename2)
        {
            bool filesAreTheSame = ExcelWriter.SaveDifrencesInExcel(filename1, filename2);
            Assert.IsTrue(filesAreTheSame, "Files are diffrent");
        }


    }
}
