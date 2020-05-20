using System;

namespace MarkdownHeaders
{
    public class Challenge
    { public static string MarkdownParser(string markdown)
        {
            markdown = markdown.Trim();
            var translation = string.Empty;
            string[] parsedInput = parseInput(markdown);
            char firstChar = parsedInput[0][0];

            if (firstChar != '#' 
                    || parsedInput[0].Length > 6
                    || !allHashes(parsedInput[0]))
            {
                translation = markdown;
            }
            else
            {
                int numHashes = parsedInput[0].Length;
                translation = String.Format($"<h{numHashes}>{parsedInput[1]}</h{numHashes}>");
            }
            return translation;
        }

        private static bool allHashes(string hashes)
        {
            var allHashes = true;
            for (int i = 0; i < hashes.Length; i++)
            {
                if (hashes[i] != '#')
                {
                    allHashes = false;
                    break;
                }
            }

            return allHashes;
        }

        private static string[] parseInput(string markdown)
        {
            string[] parsedInput = new string[2];
            int currChar = 0;
            string markdownChars = string.Empty;
            while (currChar < markdown.Length)
            {
                while (currChar < markdown.Length && markdown[currChar] != ' ')
                { 
                    markdownChars += markdown[currChar].ToString();
                    currChar++;
                }

                break;
            }

            parsedInput[0] = markdownChars;
            
            parsedInput[1] = markdown.Substring(currChar, markdown.Length - currChar).Trim();

            return parsedInput;
        }
    }
}
