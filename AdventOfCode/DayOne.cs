using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace AdventOfCode
{
    class DayOne
    {
        String FileName { get; set; }

        public DayOne()
        {
            FileName = "1input.txt";
        }

        public int GetSolution()
        {
            string[] fileLines = File.ReadAllLines(FileName);
            int sum = 2020;
            for(int i = 0; i < fileLines.Length; i++)
            {
                int num1 = Convert.ToInt32(fileLines[i]);
                for(int j = i+1; j < fileLines.Length; j++)
                {
                    int num2 = Convert.ToInt32(fileLines[j]);
                    for(int k = j+1; k < fileLines.Length; k++)
                    {
                        int num3 = Convert.ToInt32(fileLines[k]);
                        if ((num1 + num2 + num3) == sum)
                        {
                            return num1 * num2 * num3;
                        }
                    }
                    
                }
            }
            return 0; //should never be reached
        }
    }
}
