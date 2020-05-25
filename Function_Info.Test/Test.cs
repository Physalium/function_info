using System;
using System.IO;

using Function_Info.Model;

using Xunit;

namespace Function_Info_Test
{
    public class Test
    {
        public class PythonCallerTest
        {
            private PythonFileCaller model = new PythonFileCaller();

            [Fact]
            public void CallPythonTest()
            {
                string workingDirectory = Directory.GetParent(Environment.CurrentDirectory).FullName;
                string projectDirectory = Directory.GetParent(workingDirectory).Parent.FullName;
                var outputDir = Path.GetFullPath(Path.Combine(projectDirectory, @"..\Function_Info\Model\"));
                var testPath = outputDir + @"Test.txt";
                model.CreateGraph("test", "0", "0");

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

                var formula = "x**2";
                var lBound = "-10";
                var rBound = "10";
                var graphFile = Path.Combine(outputDir, "graph.png");
                model.CreateGraph(formula, lBound, rBound);
                Assert.True(File.Exists(graphFile));
            }
        }
    }
}