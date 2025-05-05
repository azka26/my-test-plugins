using System;
using System.Diagnostics;

namespace GitHubActionExample
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length > 0)
            {
                Console.WriteLine($"GitHub Action menerima input: {args[0]}");
            }
            else
            {
                Console.WriteLine("Tidak ada input yang diberikan.");
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
        }
    }
}
