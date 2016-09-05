using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BackEnd.SQL;
using Tools;
using System.Data.Sql;
using System.IO;
using System.Reflection;


namespace BackEnd.Controllers
{
    public class DB_BasicController
    {
        static string query = "";

        public static int GetCountFromGivenTable(string table)
        {
            try
            {
                query = string.Format(GenericSqls.CountFromGivenTable, table);
                Console.WriteLine(query);
                var count = ExecuteQuery.GetValueInt(query);
                Console.WriteLine("Count values in table: {0} equals: {1}", table, count);
                return count;             
                //return 101;
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public static int GetCountFromGivenTableWithCondition(string table, string condition)
        {
            try
            {
                query = string.Format(GenericSqls.CountFromGivenTableWithCondition, table, condition);
                Console.WriteLine(query);
                var count = ExecuteQuery.GetValueInt(query);
                return count;
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public static void ExecuteQueryFromFile(string file)
        {
            try
            {
                string sql = EmbeddedResource.GetString(file);
                Console.WriteLine(sql);
                ExecuteQuery.ExecuteQueryNoReturnValue(sql);
        }
            catch (Exception)
            {
                throw;
            }
        }        
    }
}
