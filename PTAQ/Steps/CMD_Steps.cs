using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using Tools;

namespace BackEnd.Steps
{
    [Binding]
    class CMD_Steps
    {
        [Given(@"following output directory: (.*)")]
        public void GivenFollowingOutputDirectoryCTestFiles( string targetFolderPath)
        {
            CMD.CMDTargetFolderPath = targetFolderPath;
        }

        [Given(@"following file name: (.*)")]
        public void GivenFollowingFileName(string fileName)
        {
            CMD.CurrentFileName = fileName;
        }

        [When(@"I copy files from (.*) into output directory")]
        public void WhenICopyFilesFromCTestFilesSourceIntoOutputDirectory(string sourceFolderPath)
        {
            string command = "Copy " + sourceFolderPath + " " + CMD.CMDTargetFolderPath;
            CMD.RunCMDCommand(command);
        }


    }
}
