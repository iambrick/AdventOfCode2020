using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace AdventOfCode
{
    class DayThree
    {
        string FileName { get; set; }
        public DayThree()
        {
            FileName = "3input.txt";
        }

        public int GetTrees()
        {
            int treeCount = 0;
            string[] fileLines = File.ReadAllLines(FileName);
            int length = fileLines[0].Length; //Length of the repeating tree pattern.
            int trackerRow = 0;
            int trackerColumn = 0;

            bool endReached = false;
            while (!endReached)
            {

                trackerRow += 1; //Down 1
                trackerColumn += 3; //Right 3

                if(trackerColumn >= length)
                {
                    int diff = trackerColumn - length;
                    trackerColumn = diff;
                }

                if (trackerRow == fileLines.Length)
                {
                    endReached = true;
                    break;
                }

                string currLine = fileLines[trackerRow];
                char currChar = currLine.ToCharArray()[trackerColumn];
                if(currChar == '#')
                {
                    treeCount++;
                }
            }


            return treeCount;
        }

        public int GetTrees(int right, int down)
        {
            int treeCount = 0;
            string[] fileLines = File.ReadAllLines(FileName);
            int length = fileLines[0].Length; //Length of the repeating tree pattern.
            int trackerRow = 0;
            int trackerColumn = 0;

            bool endReached = false;
            while (!endReached)
            {

                trackerRow += down; //Down 1
                trackerColumn += right; //Right 3

                if (trackerColumn >= length)
                {
                    int diff = trackerColumn - length;
                    trackerColumn = diff;
                }

                if (trackerRow >= fileLines.Length)
                {
                    endReached = true;
                    break;
                }

                string currLine = fileLines[trackerRow];
                char currChar = currLine.ToCharArray()[trackerColumn];
                if (currChar == '#')
                {
                    treeCount++;
                }
            }


            return treeCount;
        }

        public int Solution()
        {
            int count1 = GetTrees(1, 1);
            int count2 = GetTrees(3, 1);
            int count3 = GetTrees(5, 1);
            int count4 = GetTrees(7, 1);
            int count5 = GetTrees(1, 2);

            return (count1 * count2 * count3 * count4 * count5);
        }
    }
}
