using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEnd.SQL
{
    static class GenericSqls
    {
        public const string CountFromGivenTable = "Select COUNT (*) From {0}";
        public const string CountFromGivenTableWithCondition = "Select COUNT (*) From {0} Where {1}";        
    }
}
