using System;
using System.Collections.Generic;

namespace Args
{
    public class ArgsMain
    {
        public static void Main(string[] args)
        {
            

            Console.WriteLine("Hello World!");
        }
    }

    public class Args
    {
        private static Dictionary<char, string> argMap = new Dictionary<char, string>();
        public static void Parse(string pattern, string[] args)
        {
            string[] parsedArgs = pattern.Split(',');
            foreach (var parsedArg in parsedArgs)
            {
                if (parsedArg.Length == 1)
                {
                    argMap.Add(parsedArg.ToCharArray()[0], "false");
                }
            }

            int len = args.Length;
            int pos = 0;
            while (pos < len)
            {
                var arg = args[0];
                argMap[arg.ToCharArray()[0]] = "true";
                break;
            }
        }

        public static string GetValForArg(char arg)
        {
            return argMap[arg];
        }
    }


}
