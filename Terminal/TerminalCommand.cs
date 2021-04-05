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
            process.StartInfo.CreateNoWindow = true;
            process.StartInfo.Verb = "runas";
            process.StartInfo.WorkingDirectory = path;
            process.StartInfo.Arguments = command;
            process.Start();
            string message = process.StandardOutput.ReadToEnd();
            process.WaitForExit();

            return ("{ \"type\":\"" + "command_result" + "\", \"message\":\"" + message +  "\", \"path\":\"" + GetNewPath(command, message, path) + "\", \"deviceUid\":\"" );
           // string str = "{'message': '" + message + "', 'path': '" + GetNewPath(command, message, path) + "', 'type': '" + "command_result"+ "'}";
           // return JsonConvert.SerializeObject(str);
        }

        private static string GetNewPath(string command, string message, string path)
        {
            if (command.Trim().Split(' ')[0].ToLower().Equals("cd") && message.Equals(string.Empty))
            {
                if (command.Trim().Split(' ')[1].Contains(":")) return command.Trim().Split(' ')[1];
                if (command.Trim().Split(' ')[1].Equals("..")) return path.Remove(path.LastIndexOf('\\'));
                return path + "\\" + command.Trim().Split(' ')[1];
            }
            return path;
        }
    }
}
