using System;

namespace LetterGridBanner
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var A = new LetterGrid('A');
            A.PrintGrid();

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();

            var word = new WordGrid("A A");
            word.PrintGrid();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();

            word = new WordGrid("AAAAA");
            word.PrintGrid();



            Console.ReadLine();
        }


    }

    public class Letters
    {

        public Letters()
        {

        }
    }

    public class LetterGrid
    {
        public char[,] Grid { get; set; }
        public char Letter { get; set; }

        public LetterGrid(char letter)
        {
            Letter = letter;
            BuildGrid();
        }

        public void PrintGrid()
        {
            for (int i = 0; i < Grid.GetLength(0); i++)
            {
                for (int j = 0; j < Grid.GetLength(1); j++)
                {
                    Console.Write($"{Grid[i,j]} ");
                }

                Console.WriteLine();
            }
        }

        private void BuildGrid()
        {
            switch(Letter)
            {
                case 'a':
                case 'A':
                {
                    CreateGridForA();
                    break;
                }
                default:
                    CreateGridForSpace();
                    break;
            }
        }

        private void CreateGridForA()
        {
            Grid = new char[,]
            {
                {' ', ' ', ' ', 'A', ' ', ' ', ' ', ' '},
                {' ', ' ', 'A', ' ', 'A', ' ', ' ', ' '},
                {' ', 'A', 'A', 'A', 'A', 'A', ' ', ' '},
                {'A', ' ', ' ', ' ', ' ', ' ', 'A', ' '}
            };
        }

        private void CreateGridForSpace()
        {
            Grid = new char[,]
            {
                {' ', ' '},
                {' ', ' '},
                {' ', ' '},
                {' ', ' '}
            };
        }

        private void CreateGridForB()
        {
            Grid = new char[,]
            {
                {'B', ' ', ' ', 'A', ' ', ' ', ' ', ' '},
                {' ', ' ', 'A', ' ', 'A', ' ', ' ', ' '},
                {' ', 'A', 'A', 'A', 'A', 'A', ' ', '-'},
                {'A', ' ', ' ', ' ', ' ', ' ', 'A', '-'}
            };
        }


    }

    public class WordGrid
    {
        public char[,] Grid { get; set; }
        public string Word { get; set; }
        public int NumLettersInLine { get; set; }
        public int NumSpacesInLine { get; set; }
        public const int LetterHeight = 4;
        public const int LetterWidth = 8;
        public const int SpaceWidth = 2;

        public WordGrid(string word)
        {
            Word = word;
            GetNumberOfLettersAndSpaces();
            CreateLineGrid();
        }

        private void GetNumberOfLettersAndSpaces()
        {
            for (int i = 0; i < Word.Length; i++)
            {
                if (Word[i] == ' ')
                {
                    NumSpacesInLine++;
                }
                else
                {
                    NumLettersInLine++;
                }
            }
        }

        private void CreateLineGrid()
        {
            int xDimension = LetterHeight;
            int yDimension = LetterWidth * NumLettersInLine + SpaceWidth * NumSpacesInLine;
            Grid = new char[xDimension, yDimension];
            char[] wordCharArray = Word.ToCharArray();
            int lastIndex = 0;
            for (int i = 0; i < wordCharArray.Length; i++)
            {
                char letter = wordCharArray[i];
                LetterGrid letterGrid = new LetterGrid(letter);
                lastIndex = AddLetterGrid(lastIndex, letterGrid);
            }
        }

        private int AddLetterGrid(int lastIndex, LetterGrid letterGrid)
        {
            int lastYIndex = 0;
            if (lastIndex > 0)
            {
                lastIndex++;
            }
            for (int i = 0; i < letterGrid.Grid.GetLength(0); i++)
            {
                for (int j = 0; j < letterGrid.Grid.GetLength(1); j++)
                {
                    lastYIndex = lastIndex + j;
                    Grid[i, lastYIndex] = letterGrid.Grid[i, j];
                }
            }

            return lastYIndex;
        }

        public void PrintGrid()
        {
            for (int i = 0; i < Grid.GetLength(0); i++)
            {
                for (int j = 0; j < Grid.GetLength(1); j++)
                {
                    Console.Write($"{Grid[i, j]} ");
                }

                Console.WriteLine();
            }
        }
    }
}
