using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Microsoft.VisualBasic.FileIO;


namespace BackEnd.SQL
{
    public static class ExecuteQuery
    {
        public static SqlConnection Connection { get; private set; }

        public static SqlConnection OpenConnection(string db)
        {
            if (Connection == null)
                Connection = CreateConnection(ConfigHelper.GetActiveConnectionString(db));

            if (Connection.State != ConnectionState.Open)
                Connection.Open();

            return Connection;
        }

        public static SqlConnection CreateConnection (string db)
        {
            return new SqlConnection(ConfigHelper.GetActiveConnectionString(db));
        }

        public static void CloseConnection()
        {
            if (Connection != null)
                Connection.Dispose();
            Connection = null;
        }


       


        public static int GetValueInt(string query)
        {
            var queryCommand = new SqlCommand(query, Connection);
            var number = 0;

            try
            {
                number = (int)queryCommand.ExecuteScalar();
            }
            catch (Exception ex)
            {
                //Passing exceptions {0} not marked
                Console.WriteLine("Stacktrace: {0}", ex.StackTrace);
                Console.WriteLine("Message: {0}", ex.Message);
                Console.WriteLine("Source {0}", ex.Source);
                Console.WriteLine("Inner Exception {0}", ex.InnerException);
                throw;
            }
            return number;
        }


        public static string GetStringValue(string query)
        {
            var queryCommand = new SqlCommand(query, Connection);
            var number = "";

            try
            {
                number = queryCommand.ExecuteScalar().ToString();
            }
            catch (Exception ex)
            {
                //Passing exceptions {0} not marked
                Console.WriteLine("Stacktrace: {0}", ex.StackTrace);
                Console.WriteLine("Message: {0}", ex.Message);
                Console.WriteLine("Source {0}", ex.Source);
                Console.WriteLine("Inner Exception {0}", ex.InnerException);
                throw;
            }
            return number;
        }


        public static void ExecuteQueryNoReturnValue(string query)
        {
            var queryCommand = new SqlCommand(query, Connection);

            try
            {
                queryCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                //Passing exceptions {0} not marked
                Console.WriteLine("Stacktrace: {0}", ex.StackTrace);
                Console.WriteLine("Message: {0}", ex.Message);
                Console.WriteLine("Source {0}", ex.Source);
                Console.WriteLine("Inner Exception {0}", ex.InnerException);
                throw;
            }
        }


        public static DataTable GetExplicitReults(string query)
        {
            var queryCommand = new SqlCommand(query, Connection);
            DataTable datatable = new DataTable();

            try
            {
                queryCommand.CommandTimeout = 0;
                var reader = queryCommand.ExecuteReader();
                datatable.Load(reader);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
            return datatable;
        }


        public static void WriteQueryResultToFile(string query, string fileName)
        {
            var queryCommand = new SqlCommand(query, Connection);
            //To Enable transactions
            //queryCommand.Transaction = ActiveTransaction;
            try
            {
                queryCommand.CommandTimeout = 0;
                var reader = queryCommand.ExecuteReader();
                WriteQueryToFile(fileName, reader);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }

        }


        public static void WriteQueryResultToTwoFiles(string query, string fileName, string fileName2)
        {
            var queryCommand = new SqlCommand(query, Connection);

            try
            {
                queryCommand.CommandTimeout = 0;
                var reader = queryCommand.ExecuteReader();
                WriteQueryToFile(fileName, reader);
                if (reader.NextResult())
                {
                    WriteQueryToFile(fileName2, reader);
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }


        private static void WriteQueryToFile (string fileName, SqlDataReader reader)
        {
            using (var writer = File.AppendText(fileName))
            {
                while (reader.Read())
                {
                    var row = new StringBuilder();
                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        row.Append(reader[i]);
                        if (i != reader.FieldCount - 1) row.Append("|");
                    }
                    writer.WriteLine(row);
                }
                writer.Close();
                reader.Close();
            }           
        }


        public static void UploadDataFromFile(string fileName, string table)
        {
            string query;
            string line;
            var queryCommand = new SqlCommand();
            StreamReader file = new StreamReader(fileName);

            while ((line = file.ReadLine()) != null)
            {
                line = line.Replace("'", "''").Replace("|", "', '");
                line = "Insert Into " + table + " Values ('" + line + "')";
                line = line.Replace(", ''", ", NULL").Replace("'',", "NULL ,");
                query = line;
                queryCommand.CommandText = query;
                queryCommand.Connection = Connection;
                //queryCommand.Transaction = ActiveTransation;
                Console.WriteLine(query);
                queryCommand.ExecuteNonQuery();
            }
            file.Close();
        }

        #region Not used now. Remeber about adding reference to Microsoft.VisualBasic

        public static DataTable GetDataTableFromCSVFIle(string csvFilePath)
        {
            DataTable csvData = new DataTable();
            try
            {
                using (TextFieldParser csvReader = new TextFieldParser(csvFilePath))
                {
                    csvReader.SetDelimiters(new string[] { "|" });
                    csvReader.HasFieldsEnclosedInQuotes = false;
                    string[] colFields = csvReader.ReadFields();
                    foreach (string column in colFields)
                    {
                        DataColumn datacolumn = new DataColumn(column);
                        datacolumn.AllowDBNull = true;
                        csvData.Columns.Add(datacolumn);
                    }
                    while (!csvReader.EndOfData)
                    {
                        string[] fieldData = csvReader.ReadFields();
                        for(int i=0; i <fieldData.Length; i++)
                        {
                            if (fieldData[i] == "")
                            {
                                fieldData[i] = null;
                            }
                        }
                        csvData.Rows.Add(fieldData);
                    }

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
            return csvData;
        }


        public static void InsertDataIntoTableUsingBulkCopy (DataTable csvFileData, string destinationTable)
        {
            using (SqlBulkCopy s = new SqlBulkCopy(Connection))
            {
                s.DestinationTableName = destinationTable;
                foreach (var column in csvFileData.Columns)
                    s.ColumnMappings.Add(column.ToString(), column.ToString());
                s.WriteToServer(csvFileData);
            }
        }
        #endregion

    }
}
