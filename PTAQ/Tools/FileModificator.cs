using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Tools
{

    //Class is not used in any test yet
    class FileModificator
    {
        public void AddRow()
        {
            string path = "";
            string currency = "PLN";
            string text = "PL,Country PL,Region12,1,Y," + currency;
            var lines = File.ReadAllLines(path);
            bool lineAdded = false;
            for(int i = 0; i < lines.Length; i++)
            {
                if (lines[i].StartsWith("PL"))
                {
                    lines[i] = text;
                    lineAdded = true;
                    break;
                }
            }
            if (!lineAdded)
            {
                File.AppendAllText(path, text + Environment.NewLine);
            }
            else
            {
                File.WriteAllLines(path,lines);
            }
        }


        public void DeleteRow()
        {
            string path = "";
            var lines = File.ReadAllLines(path);
            int lineToRemove = lines.Length;
            for (int i = 0; i < lines.Length; i++)
            {
                if (!lines[i].StartsWith("PL")) continue;
                lineToRemove = i;
                break;
            }
            if (lineToRemove != lines.Length)
            {
                File.WriteAllLines(path, lines.Take(lineToRemove).Concat(lines.Skip(lineToRemove + 1)));
            }
        }
    }
}
