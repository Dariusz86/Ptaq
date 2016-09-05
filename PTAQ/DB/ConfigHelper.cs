using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace BackEnd.SQL
{
    public static class ConfigHelper
    {
        public static string GetActiveConnectionString(string dataBase)
        {
            return ConfigurationManager.ConnectionStrings["TargetDB"].ConnectionString;
        }
    }
}
