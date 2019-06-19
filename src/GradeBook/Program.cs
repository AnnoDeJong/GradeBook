using System;
using System.Collections.Generic;

namespace GradeBook
{
    class Program
    {
        static void Main(string[] args)
        {
            var book = new Book("Andre's Grade Book");
            book.AddGrade(55);
            book.AddGrade(65.5);
            book.AddGrade(75.4);
            book.AddGrade(44.4);

            var stats = book.GetStatistics();

            Console.WriteLine($"The lowest grade is: {stats.low}");
            Console.WriteLine($"The highest grade is: {stats.high}");
            Console.WriteLine($"The average grade is: {stats.average}");
        }

    }
}
