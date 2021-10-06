using System;
using System.Collections.Generic;
using System.Text;

namespace KWIC_Index
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }

    public class KWICIndex
    {
        public List<string> CreateIndex(List<string> titles)
        {
            var index = new List<string>();
            if (titles.Count == 0)
            {
                return index;
            }

            foreach (var title in titles)
            {
                var words = SplitIntoWords(title);
                var rotatedLines = CreateRotatedLines(words);
                foreach (var line in rotatedLines)
                {
                    index.Add(line);
                }
            }

            var sortedLines = SortLines(index);

            return sortedLines;
        }

        private List<string> SortLines(List<string> index)
        {
            return index;
        }

        private List<string> CreateRotatedLines(string[] words)
        {
            var lines = new List<string>();
            for (int i = 0; i < words.Length; i++)
            {
                lines.Add(RotateLine(i, words));
            }

            return lines;

        }

        private string RotateLine(int pos, string[] words)
        {
            var strBuilder = new StringBuilder();
            for (int i = 0; i < words.Length; i++)
            {
                strBuilder.Append(words[pos++ % words.Length]);
                if (i < words.Length - 1)
                {
                    strBuilder.Append(' ');
                }
            }
            return strBuilder.ToString();
        }

        private string[] SplitIntoWords(string title)
        {
             return title.Split(' ');
        }
    }

    /*
        Key Word in Context (KWIC) The KWIC index system accepts as input an ordered set of lines, 
        each line is an ordered set of words, and each word is an ordered set of characters. Any 
        line may be “circularly shifted” by repeatedly removing the first word and appending it 
        at the end of the line. The KWIC index system outputs a listing of all circular shifts of 
        all lines in alphabetical order of the keyword used to shift the line 
        – Common (stop) words may be omitted

        Example:

        Original title – Gone with the Wind 

        • Circular shifts  
        – Gone with the Wind 
        – with the Wind Gone 
        – the Wind Gone with 
        – Wind Gone with the 

        • Stop word removal 
        – Gone with the Wind 
        – Wind Gone with the








     */
}
