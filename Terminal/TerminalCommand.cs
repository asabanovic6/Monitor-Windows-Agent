using Newtonsoft.Json;
using System.Diagnostics;

namespace TerminalLibrary
{
    public class TerminalCommand
    {
        public static string RunCommand(string command, string path)
        {
            var process = new Process();
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.RedirectStandardOutput = true;
            process.StartInfo.FileName = "powershell.exe";
            process.StartInfo.WindowStyle = ProcessWindowStyle.Normal;
            process.StartInfo.Verb = "runas";
            process.StartInfo.WorkingDirectory = path;
            process.StartInfo.Arguments = command;
            process.Start();
            string message = process.StandardOutput.ReadToEnd();
            process.WaitForExit();
            string str = "{'message': '" + message + "', 'path': '" + GetNewPath(command, message, path) + "'}";
            return JsonConvert.SerializeObject(str);
        }

        private static string GetNewPath(string command, string message, string path)
        {
            if (command.Trim().Split(' ')[0].ToLower().Equals("cd") && message.Equals(string.Empty)) return path + "\\" + command.Trim().Split(' ')[1];
            else if (command.Trim().Split(' ')[0].ToLower().Equals("cd..") && message.Equals(string.Empty)) return path.Remove(path.LastIndexOf('\\'));
            return path;
        }
    }
}
