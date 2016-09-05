using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using OfficeOpenXml.Table;
using System.IO;
using System.Drawing;


namespace Tools
{
    class ExcelWriter
    {
        public static void WriteDataTableToXLS (DataTable data, string filePath)
        {
            filePath = filePath + "_" + DateTime.Now.ToString("yyyyMMdd_HH-mm") + ".xlsx";
            ExcelPackage package = new ExcelPackage(new System.IO.FileInfo(filePath));
            ExcelWorksheet ws = package.Workbook.Worksheets.Add("fact");
            //LoadFrom DataTable/Text/DataReader
            ws.Cells[1, 1].LoadFromDataTable(data, true, TableStyles.Medium15);

            ExcelRange range = ws.Cells[ws.Dimension.Address];
            //var table = ws.Tables[0].TableXml.DocumentElement;
            //table.Attributes["ref"].Value = range.Address;
            range.AutoFitColumns();

            package.Save();
        }


        public static bool SaveDifrencesInExcel(string filename1, string filename2)
        {
            List<String> linesFromFile1 = ReadFileLines(CMD.CMDTargetFolderPath + "\\" + filename1);
            List<String> linesFromFile2 = ReadFileLines(CMD.CMDTargetFolderPath + "\\" + filename2);
            //String header = "";
            bool filesAreTheSame = true;

            using (ExcelPackage package = new ExcelPackage())
            {
                ExcelWorksheet ws1 = package.Workbook.Worksheets.Add(filename1);
                ExcelWorksheet ws2 = package.Workbook.Worksheets.Add(filename2);
                //addHeaderRow(ExcelHeaderFooter, ws1, ws2);
                int row = 2;
                for (int i = 0; i <linesFromFile1.Count; i++)
                {
                    if (linesFromFile1[i] != linesFromFile2[i])
                    {
                        int column = 1;
                        var values1 = linesFromFile1[i].Split('|');
                        var values2 = linesFromFile2[i].Split('|');
                        filesAreTheSame = false;
                        for (int j = 0; j < values1.Count(); j++)
                        {
                            ExcelRange cell1 = ws1.Cells[row, column];
                            cell1.Value = values1[j];
                            ExcelRange cell2 = ws2.Cells[row, column];
                            cell2.Value = values2[j];
                            if (values1[j] != values2[j])
                            {
                                cell1.Style.Fill.PatternType = ExcelFillStyle.Solid;
                                cell1.Style.Fill.BackgroundColor.SetColor(Color.Tomato);
                                cell2.Style.Fill.PatternType = ExcelFillStyle.Solid;
                                cell2.Style.Fill.BackgroundColor.SetColor(Color.Tomato);
                            }
                            column++;
                        }
                        row++;
                    }
                }
                if (filesAreTheSame != true)
                {
                    ExcelRange range1 = ws1.Cells[ws1.Dimension.Address];
                    range1.AutoFitColumns();
                    ExcelRange range2 = ws2.Cells[ws2.Dimension.Address];
                    range2.AutoFitColumns();
                    String path = CMD.CMDTargetFolderPath + "\\" + "CompareResultsOfTwoFlatFiles" + "_" + DateTime.Now.ToString("yyyyMMdd_HH-mm") + ".xlsx";
                    package.SaveAs(new FileInfo(path));
                    //OR
                    //FileInfo fInf = new FileInfo(path);
                    //package.SaveAs(fInf);
                }
            }
            return filesAreTheSame;
        } 


        private static List<string> ReadFileLines(string filename)
        {
            List<String> lines = new List<String>();
            using (StreamReader reader = new StreamReader(filename))
            {
                String line;
                while ((line = reader.ReadLine()) != null)
                {
                    lines.Add(line);
                }
            }
            return lines;
        }

    }
}
