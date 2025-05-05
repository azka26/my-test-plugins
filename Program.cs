using System;
using System.Diagnostics;

namespace GitHubActionExample
{
    class Program
    {
        static void Main(string[] args)
        {
            var buildParameter = new BuildParameter(args);
            Console.WriteLine($"Parameter {nameof(buildParameter.Mode)}: {buildParameter.Mode}");
            Console.WriteLine($"Parameter {nameof(buildParameter.FrontendPath)}: {buildParameter.FrontendPath}");
            Console.WriteLine($"Parameter {nameof(buildParameter.BackendPath)}: {buildParameter.BackendPath}");
            Console.WriteLine($"Parameter {nameof(buildParameter.TestPath)}: {buildParameter.TestPath}");
            Console.WriteLine($"Parameter {nameof(buildParameter.BackendAppsettingsTransform)}: {buildParameter.BackendAppsettingsTransform}");
            Console.WriteLine($"Parameter {nameof(buildParameter.TestAppsettingsTransform)}: {buildParameter.TestAppsettingsTransform}");
            Console.WriteLine($"Parameter {nameof(buildParameter.EnvTransform)}: {buildParameter.EnvTransform}");

            // Run a bash command
            Console.WriteLine("Executing bash command...");
            ProcessStartInfo startInfo = new ProcessStartInfo
            {
                FileName = "/bin/bash",
                Arguments = "-c \"dotnet --version\"",
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
