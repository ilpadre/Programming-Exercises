using System;

namespace ResistorValidator
{
    class Program
    {
        static void Main(string[] args)
        {
            Validator validator = new Validator();

            Tests test = new Tests();
            test.RunTests(validator);

            Console.WriteLine("Done");
        }
    }
}
