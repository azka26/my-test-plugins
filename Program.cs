using System;

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
        }
    }
}
