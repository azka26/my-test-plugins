using System;
using System.Diagnostics;

namespace GitHubActionExample
{
    class Program
    {
        static void Main(string[] args)
        {
            var argsString = string.Join(" ", args);
            var argsSplit = argsString.Split("--", StringSplitOptions.RemoveEmptyEntries);
            foreach (var arg in argsSplit)
            {
                var parameter = arg.Split("=", StringSplitOptions.RemoveEmptyEntries);
                Console.WriteLine($"Arg: {parameter[0]}, Value: {parameter[1]}");
            }

            // Run a bash command
            Console.WriteLine("Executing bash command...");
            ProcessStartInfo startInfo = new ProcessStartInfo
            {
                FileName = "/bin/bash",
                Arguments = "-c \"echo 'Hello from Bash'\"",
                RedirectStandardOutput = true,
                UseShellExecute = false,
                CreateNoWindow = true
            };

            try
            {
                using (Process process = Process.Start(startInfo))
                {
                    string output = process.StandardOutput.ReadToEnd();
                    process.WaitForExit();
                    Console.WriteLine($"Bash output: {output}");
                    Console.WriteLine($"Exit code: {process.ExitCode}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error executing bash command: {ex.Message}");
            }

            
            Console.WriteLine("CURRENT DIRECTORY : " + Directory.GetCurrentDirectory());
            Console.WriteLine("GitHub Action selesai.");
            throw new Exception("This is a test exception to simulate a failure in the GitHub Action.");
        }
    }
}
