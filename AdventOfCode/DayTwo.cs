using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace AdventOfCode
{
    class DayTwo
    {
        public String FileName { get; set; }


        public DayTwo()
        {
            FileName = "2input.txt";
        }

        public int SolutionOne()
        {
            string[] fileLines = File.ReadAllLines(FileName);
            int count = 0;
            foreach(string line in fileLines)
            {
                string[] currLine = line.Split(' ');
                //min-max, letter:, password
                char letter = currLine[1].ToCharArray()[0];
                string[] minMax = currLine[0].Split('-');
                //min and max
                int min = Convert.ToInt32(minMax[0]);
                int max = Convert.ToInt32(minMax[1]);

                if(IsValid(min, max, letter, currLine[2]))
                {
                    count++;
                }
                
                
            }

            return count;
        }

        public bool IsValid(int min, int max, char letter, string password)
        {
            char[] charArray = password.ToCharArray();
            int letterCount = 0;
            for(int i = 0; i < charArray.Length; i++)
            {
                if(charArray[i] == letter)
                {
                    letterCount++;
                }
            }
            return (letterCount <= max && letterCount >= min);
        }

        public bool SecondValid(int indexOne, int indexTwo, char letter, string password)
        {
            char[] charArray = password.ToCharArray();
            bool firstValid = false;
            bool secondValid = false;
            if(charArray[indexOne] == letter) 
            {
                firstValid = true;
            }
            if(charArray[indexTwo] == letter)
            {
                secondValid = true;
            }
            return (firstValid && !secondValid || !firstValid && secondValid);
        }

        public int SolutionTwo()
        {
            string[] fileLines = File.ReadAllLines(FileName);
            int count = 0;
            foreach (string line in fileLines)
            {
                string[] currLine = line.Split(' ');
                //indexes, letter:, password
                char letter = currLine[1].ToCharArray()[0];
                string[] indexes = currLine[0].Split('-');
                //indexes
                int indexOne = Convert.ToInt32(indexes[0]) - 1; //Minus one because the company doesn't know what 0 index is
                int indexTwo = Convert.ToInt32(indexes[1]) - 1;

                if(SecondValid(indexOne, indexTwo, letter, currLine[2]))
                {
                    count++;
                }


            }
            return count;
        }
    }
}
