namespace GitHubActionExample
{
    public class BuildParameter 
    {
        public BuildParameter(string[] args)
        {
            if (args.Length == 0)
            {
                throw new ArgumentException("No arguments provided.");
            }

            var argsString = string.Join(" ", args);
            var argsSplit = argsString
                .Split("--", StringSplitOptions.RemoveEmptyEntries)
                .Select(f => f.Trim())
                .ToList();
            
            foreach (var arg in argsSplit)
            {
                Console.WriteLine($"Processing argument: {arg}");

                var parameters = arg.Split("=", StringSplitOptions.None);
                var parameterName = parameters[0].Trim().ToLower();
                var parameterValues = new List<string>();
                for (int i = 0; i < parameters.Length; i++)
                {
                    if (i == 0)
                    {
                        continue; // Skip the first element as it is the parameter name
                    }
                    parameterValues.Add(parameters[i]!);
                }
                var parameterValue = string.Join("=", parameterValues);
                if (parameterName == "mode")
                {
                    Mode = parameterValue;
                }
                else if (parameterName == "frontend-path")
                {
                    FrontendPath = parameterValue;
                }
                else if (parameterName == "backend-path")
                {
                    BackendPath = parameterValue;
                }
                else if (parameterName == "test-path")
                {
                    TestPath = parameterValue;
                }
                else if (parameterName == "backend-appsettings-transform")
                {
                    BackendAppsettingsTransform = parameterValue;
                }
                else if (parameterName == "test-appsettings-transform")
                {
                    TestAppsettingsTransform = parameterValue;
                }
                else if (parameterName == "env-transform")
                {
                    EnvTransform = parameterValue;
                }
            }
        }
        /// <summary>
        /// Mode should be either "deploy" or "test".
        /// "deploy" will deploy the application to the server.
        /// "test" will run the tests on the application.
        /// </summary>
        public string Mode { get; } = "deploy";

        /// <summary>
        /// Path to the frontend directories.
        /// </summary>
        public string? FrontendPath { get; }

        /// <summary>
        /// Path to the backend directories.
        /// </summary>
        public string? BackendPath { get; }

        /// <summary>
        /// Path to the test directories.
        /// </summary>
        public string? TestPath { get; }
        public string? BackendAppsettingsTransform { get; }
        public string? TestAppsettingsTransform { get; }
        public string? EnvTransform { get; }
    }
}
