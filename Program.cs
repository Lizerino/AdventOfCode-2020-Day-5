using System;

namespace Day_5
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            string puzzleInput = System.IO.File.ReadAllText("E:\\Archive\\Repos\\MyCode\\Advent of Code\\2020\\Day 5\\input.txt");
            var splitInput = puzzleInput.Split(Environment.NewLine);

            int highestSeatID = 0;
            var seatsTaken = new string[128, 8];
            foreach (var inputRow in splitInput)
            {
                var seatRow = checkRow(inputRow);
                var seatColumn = checkColumn(inputRow);
                seatsTaken[seatRow, seatColumn] = "X";
            }

            
                for (int i = 1; i < 126; i++)
                {                
                for (int j = 1; j < 7; j++)
                {                
                    if (seatsTaken[i,j]!="X")
                    {
                        Console.WriteLine($"Row: {i}, Column: {j}");
                    }
                }
            }

            Console.WriteLine(highestSeatID);
        }

        private static int checkColumn(string inputRow)
        {
            int rowBottom = 0;
            int rowTop = 7;
            foreach (var character in inputRow)
            {
                if (character == 'R')
                {
                    rowBottom = rowBottom + ((rowTop - rowBottom) / 2) + 1;
                }
                if (character == 'L')
                {
                    rowTop = rowBottom + ((rowTop - rowBottom) / 2);
                }
            }
            return rowBottom;
        }

        private static int checkRow(string input)
        {
            int rowBottom = 0;
            int rowTop = 127;
            foreach (var character in input)
            {
                if (character == 'B')
                {
                    rowBottom = rowBottom + ((rowTop - rowBottom) / 2) + 1;
                }
                if (character == 'F')
                {
                    rowTop = rowBottom + ((rowTop - rowBottom) / 2);
                }
            }
            return rowBottom;
        }
    }
}