using SO.AppStart;

namespace App.StringOperation
{
    class MainProgram
    {
        public static void Main(string[] args)
        {
            AppStart app = new(args);
            app.StartApplication();
        }
    }
}