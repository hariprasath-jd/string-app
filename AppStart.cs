using System.CommandLine;
using System.CommandLine.Invocation;
using System.CommandLine.Parsing;

namespace SO.AppStart
{

    class AppStart
    {
        // to get and set the argument values from the main method.
        private string[] arg;

        private readonly Option printOption = new Option<string>(new string[] { "-p", "--print" }, "Print the converted value.");

        private readonly Option inputFileOption = new Option<FileInfo>(new string[] { "-i", "--input" }, "input file to convert a file's case.");

        private readonly Option outputFileOption = new Option<string>(new string[] { "-o", "--output" }, "returns the output in the mentioned filename");

        private readonly Option lowerOption = new Option<bool>(new string[] { "-l", "--lower" }, "Returns the output in Lower case")
        {
            Arity = ArgumentArity.ExactlyOne
        };
        private readonly Option upperOption = new Option<bool>(new string[] { "-u", "--upper" }, "Returns the output in Upper case")
        {
            Arity = ArgumentArity.ExactlyOne
        };

        public AppStart(string[] arg)
        {
            this.arg = arg;
        }


        public void StartApplication()
        {
            if (RootChecker.IsRoot())
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("This tools Requires root access");
                Console.ForegroundColor = ConsoleColor.White;
                return;
            }
            var c = new RootCommand();
            c.AddOption(printOption);
            c.AddOption(inputFileOption);
            c.AddOption(lowerOption);
            c.AddOption(upperOption);

            c.SetHandler(pr => HandleValues(pr));

            c.Invoke(arg);
        }

        private void HandleValues(InvocationContext pr)
        {
            var output = pr.ParseResult.GetValueForOption(printOption);
            var input = pr.ParseResult.GetValueForOption(inputFileOption);
            var upper = pr.ParseResult.GetValueForOption(lowerOption);
            var lower = pr.ParseResult.GetValueForOption(upperOption);

            if((bool) upper && upper != null){
                lowerOption.Arity = ArgumentArity.Zero;
            }
            else if ((bool) lower && lower != null){

                upperOption.Arity = ArgumentArity.Zero;
            }
            else {
                
            }

            Console.WriteLine(lower+" - "+upper);
        }
    }
}