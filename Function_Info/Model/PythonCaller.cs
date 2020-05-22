using System;
using System.Diagnostics;

namespace Function_Info.Model
{
    public static class PythonFileCaller
    {
        public static void CreateGraph(string functionFormula, string leftBound, string rightBound)
        {
            Process process = new System.Diagnostics.Process();
            ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
            startInfo.WindowStyle=ProcessWindowStyle.Normal;
            //startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            startInfo.FileName = "cmd.exe";
            startInfo.Arguments = @"/C cd C:\Users\Karol\Desktop\Projekty\Function_Info\Function_Info\Model\& python graph.py "
            +$"{functionFormula} {leftBound} {rightBound}";
            startInfo.Verb = "runas";
            process.StartInfo = startInfo;
            process.Start();

            process.WaitForExit();
        }

    }
}
