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
                var testPath = outputDir + @"Test.txt";
                fi.PythonFileCaller.CreateGraph("test", "0", "0");

                string text;
                try
                {
                    text = File.ReadAllText(testPath);

                }
                catch (System.Exception)
                {
                    System.Console.WriteLine(outputDir);
                    text = string.Empty;
                }
                finally
                {
                    File.Delete(testPath);
                }
                var expected = "test";
                Assert.Equal(expected, text);

            }

            [Fact]
            public void createGraphTest()
            {
                string workingDirectory = Directory.GetParent(Environment.CurrentDirectory).FullName;
                string projectDirectory = Directory.GetParent(workingDirectory).Parent.FullName;
                var outputDir = Path.GetFullPath(Path.Combine(projectDirectory, @"..\Function_Info\Model\"));

                var formula = "x*2+2";
                var lBound = "-3";
                var rBound = "3";
                var graphFile = Path.Combine(outputDir, "graph.png");
                fi.PythonFileCaller.CreateGraph(formula, lBound, rBound);
                Assert.True(File.Exists(graphFile));

            }
        }
    }

}
