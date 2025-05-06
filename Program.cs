using System;
using System.Diagnostics;

namespace GitHubActionExample
{
    class Program
    {
        static bool RunProcess(string fileName, string arguments, string workingDirectory, out string output, out string error)
        {
            Process process = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = fileName,
                    Arguments = arguments,
                    WorkingDirectory = workingDirectory,
                    RedirectStandardOutput = true, // Redirect output to read it
                    RedirectStandardError = true,  // Redirect error output
                    UseShellExecute = false,       // Required for redirection
                    CreateNoWindow = true          // Run without creating a console window
                }
            };

            process.Start();
            output = process.StandardOutput.ReadToEnd();
            error = process.StandardError.ReadToEnd();
            
            process.WaitForExit();
            if (string.IsNullOrEmpty(error))
            {
                return true;
            }

            return false;
        }

        // static bool RunDotnetRestore(BuildParameter parameter)
        // {
        //     if (string.IsNullOrEmpty(parameter.BackendPath)){
        //         return true;
        //     }



        //     var pathBackend = parameter.BackendPath;
        //     var path = Path.Combine(Directory.GetCurrentDirectory(), parameter.FrontendPath ?? parameter.BackendPath);

        //     string workingDirectory = buildParameter.FrontendPath ?? buildParameter.BackendPath;
        //     string arguments = "restore";

        //     return RunProcess("dotnet", arguments, workingDirectory, out output, out error);
        // }

        static void RunTest(BuildParameter buildParameter)
        {
            if (string.IsNullOrWhiteSpace(buildParameter.TestPath))
            {
                throw new Exception("Test path is not provided.");
            }

            if (string.IsNullOrEmpty(buildParameter.TestAppsettingsTransform))
            {
                throw new Exception("Test appsettings transform is not provided.");
            }

            var path = Path.Combine(Directory.GetCurrentDirectory(), buildParameter.TestPath);
            Console.WriteLine($"Running tests in path: {path}");
            Console.WriteLine($"Test appsettings transform: {buildParameter.TestAppsettingsTransform}");
        }

        static void RunBuild(BuildParameter buildParameter)
        {
            Console.WriteLine("Running build...");
            // Add your build logic here
        }

        static void Main(string[] args)
        {
            var argsString = string.Join(" ", args);
            Console.WriteLine($"Arguments: {argsString}");

            // var stringValue = "\"ConnectionStrings.default\":\"datavaluefortransformer,asdasdasd;asdasd.,asdasd\",\"valueNeedTransform\":\"test with space\",\"otherValue\":\"test test testx\"";
            // var jsonFormat = $"{{{stringValue}}}";
            // var jsonParse = Newtonsoft.Json.JsonConvert.DeserializeObject(jsonFormat);
            // var buildParameter = new BuildParameter(args);
            // Console.WriteLine($"Parameter {nameof(buildParameter.Mode)}: {buildParameter.Mode}");
            // Console.WriteLine($"Parameter {nameof(buildParameter.FrontendPath)}: {buildParameter.FrontendPath}");
            // Console.WriteLine($"Parameter {nameof(buildParameter.BackendPath)}: {buildParameter.BackendPath}");
            // Console.WriteLine($"Parameter {nameof(buildParameter.TestPath)}: {buildParameter.TestPath}");
            // Console.WriteLine($"Parameter {nameof(buildParameter.BackendAppsettingsTransform)}: {buildParameter.BackendAppsettingsTransform}");
            // Console.WriteLine($"Parameter {nameof(buildParameter.TestAppsettingsTransform)}: {buildParameter.TestAppsettingsTransform}");
            // Console.WriteLine($"Parameter {nameof(buildParameter.EnvTransform)}: {buildParameter.EnvTransform}");

            // if (buildParameter.Mode == "test")
            // {
            //     RunTest(buildParameter);
            // }
            // else if (buildParameter.Mode == "build")
            // {
            //     RunBuild(buildParameter);
            // }
            // else
            // {
            //     throw new Exception($"Unknown mode: {buildParameter.Mode}");
            // }

            // // Run a bash command
            // Console.WriteLine("Executing bash command...");
            // ProcessStartInfo startInfo = new ProcessStartInfo
            // {
            //     FileName = "/bin/bash",
            //     Arguments = "-c \"dotnet --version\"",
            //     RedirectStandardOutput = true,
            //     UseShellExecute = false,
            //     CreateNoWindow = true
            // };

            // try
            // {
            //     using (Process process = Process.Start(startInfo))
            //     {
            //         string output = process.StandardOutput.ReadToEnd();
            //         process.WaitForExit();
            //         Console.WriteLine($"Bash output: {output}");
            //         Console.WriteLine($"Exit code: {process.ExitCode}");
            //     }
            // }
            // catch (Exception ex)
            // {
            //     Console.WriteLine($"Error executing bash command: {ex.Message}");
            // }

            
            // Console.WriteLine("CURRENT DIRECTORY : " + Directory.GetCurrentDirectory());
            // Console.WriteLine("GitHub Action selesai.");
            // throw new Exception("This is a test exception to simulate a failure in the GitHub Action.");
        }
    }
}
