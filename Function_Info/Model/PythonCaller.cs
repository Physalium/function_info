using System.Diagnostics;

namespace Function_Info.Model
{
    public class PythonFileCaller
    {
        public void CreateGraph(string functionFormula, string leftBound, string rightBound)
        {
            Process cmd = new Process();
            cmd.StartInfo.FileName = "cmd.exe";
            cmd.StartInfo.Arguments = @"/C cd C:\Users\Karol\Desktop\Projekty\Function_Info\Function_Info\Model\& python graph.py "
            + $"{functionFormula} {leftBound} {rightBound}";
            cmd.StartInfo.Verb = "runas";
            cmd.StartInfo.CreateNoWindow = true;
            cmd.Start();
            cmd.WaitForExit();
        }
    }
}