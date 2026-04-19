using System;
using System.Collections.Generic;

namespace Lab9.Green
{
    class Program2
    {
        static void Main(string[] args)
        {
            Subject sub1 = new Subject("S01", "Code C#", 3);

            Mark m1 = new Mark("SV001", "S01", 8.5);

            Console.WriteLine("--- Subject info ---");
            sub1.DisplaySubject();

            Console.WriteLine("\n--- Grade info ---");
            m1.DisplayMark();

            Console.ReadLine();
        }
    }
}
