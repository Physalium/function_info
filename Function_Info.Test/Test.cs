using System;
using System.IO;
using System.Reflection;
using Xunit;

namespace Function_Info_Test
{
    using fi = Function_Info.Model;
    public class Test
    {
        public class PythonCallerTest
        {
            [Fact]
            public void CallPythonTest()
            {
                string workingDirectory = Directory.GetParent(Environment.CurrentDirectory).FullName;
                string projectDirectory = Directory.GetParent(workingDirectory).Parent.FullName;
                var outputDir = Path.GetFullPath(Path.Combine(projectDirectory, @"..\Function_Info\Model\"));
                fi.PythonFileCaller.CreateGraph("test", "0", "0");

                string text;
                try
                {
                    text = File.ReadAllText(outputDir + @"Test.txt");

                }
                catch (System.Exception)
                {
                    System.Console.WriteLine(outputDir);
                    text=string.Empty;
                }
                var expected="test";
                Assert.Equal(expected,text);
            }
        }
    }

}
