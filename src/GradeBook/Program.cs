using System;
using System.Collections.Generic;

namespace GradeBook
{
    class Program
    {
        static void Main(string[] args)
        {
            IBook book = new DiskBook("Andre's Grade Book");

            book.GradeAdded += OnGradeAdded;

            EnterGrades(book);

            var stats = book.GetStatistics();

            Console.WriteLine($"For the book name {book.Name}");
            Console.WriteLine($"The lowest grade is: {stats.low}");
            Console.WriteLine($"The highest grade is: {stats.high}");
            Console.WriteLine($"The average grade is: {stats.average:N2}");
            Console.WriteLine($"The letter grade is: {stats.letter}");
        }

        private static void EnterGrades(IBook book)
        {
            while (true)
            {
                Console.WriteLine("Enter a grade or enter 'q' to quit");
                var userInput = Console.ReadLine();

                if (userInput == "q" || userInput == "Q")
                {
                    break;
                }

                try
                {
                    var gradeToAdd = double.Parse(userInput);
                    book.AddGrade(gradeToAdd);
                }
                catch (ArgumentNullException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch (FormatException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    throw;
                }
                finally
                {
                    Console.WriteLine("**");
                }
            }
        }

        static void OnGradeAdded(object sender, EventArgs e)
        {
            Console.WriteLine("A grade was added");
        }
    }
}
