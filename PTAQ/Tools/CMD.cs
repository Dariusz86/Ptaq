using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tools
{
    public class CMD
    {
        public static string CMDTargetFolderPath
        {
            get;
            set;
        }


        public static string CurrentFileName
        {
            get;
            set;
        }


        public static string RunCMDCommand(string command)
        {
            System.Diagnostics.Process process = new System.Diagnostics.Process();
            System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();

            startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            startInfo.FileName = "cmd.exe";
            startInfo.RedirectStandardOutput = true;
            startInfo.RedirectStandardInput = true;
            startInfo.RedirectStandardError = true;
            startInfo.UseShellExecute = false;
            process.StartInfo = startInfo;

            process.Start();
            //process.StandardInput.WriteLine("cd " + CMDFolderPath);
            process.StandardInput.WriteLine(command);
            process.StandardInput.Close();
            string consoleOutput = process.StandardOutput.ReadToEnd();
            Console.WriteLine(consoleOutput);
            return consoleOutput;            
        }
    }
}
