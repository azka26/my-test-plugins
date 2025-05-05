namespace GitHubActionExample
{
    class BuilderParameter {

        /// <summary>
        /// Path to the frontend directories.
        /// </summary>
        public string FrontendPath { get; set; }

        /// <summary>
        /// Path to the backend directories.
        /// </summary>
        public string BackendPath { get; set; }

        /// <summary>
        /// Path to the test directories.
        /// </summary>
        public string TestPath { get; set; }

        /// <summary>
        /// Mode should be either "deploy" or "test".
        /// "deploy" will deploy the application to the server.
        /// "test" will run the tests on the application.
        /// </summary>
        public string Mode { get; set; } = "deploy";

        /// <summary>
        /// Dotnet environment
        /// </summary>
        public string Environment { get; set; } = "production";
        
    }
}
