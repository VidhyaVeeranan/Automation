using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using System.IO;

namespace ConsoleApp2.BusinessLibrary
{
    public class TestBase
    {
        string filePath = System.AppDomain.CurrentDomain.BaseDirectory + "Reports\\Report.txt";

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            WriteToFile("**************************************");
            WriteToFile("Test Execution Begins");
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            WriteToFile("Test Execution Ends");
            WriteToFile("**************************************");
        }
        
        public void WriteToFile(string text)
        {
            File.AppendAllText(filePath, text + Environment.NewLine);
        }
    }
}
