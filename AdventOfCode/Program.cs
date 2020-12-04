using System;

namespace AdventOfCode
{
    class Program
    {
        static void Main(string[] args)
        {
            DayOne day = new DayOne();

            DayTwo two = new DayTwo();

            DayThree three = new DayThree();
            Console.WriteLine(new DayFour().CountValid());
        }
    }
}
