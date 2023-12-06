using System;
using System.CommandLine;

namespace App.StringOperation {
    class MainProgram
    {
        public static void Main(string[] args)
        {
            var printOption = new Option<string>(new string[] {"-p","--print"},"Print the given value.");

            var c = new RootCommand();
            c.AddOption(printOption);

            c.SetHandler(pr => {
                var output = pr.ParseResult.GetValueForOption(printOption);
                Console.WriteLine($"{output}");
            });
            c.Invoke(args);
        }
    }
}