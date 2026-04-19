using System;

namespace Lab9.Green
{
    public class Task4
    {
        public static void Main(string[] args)
        {
            Task2 sub1 = new Task2("S01", "Code C#", 3);

            Task3 m1 = new Task3("SV001", "S01", 8.5);

            Console.WriteLine("--- Subject info ---");
            sub1.DisplaySubject();

            Console.WriteLine("\n--- Grade info ---");
            m1.DisplayMark();

            Console.ReadLine();
        }
    }
}
