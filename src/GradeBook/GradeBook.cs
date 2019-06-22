using System;
using System.Collections.Generic;

namespace GradeBook
{
    public class Book
    {
        public Book(string name)
        {
            grades = new List<double>();
            Name = name;
        }

        public void AddGrade(double grade)
        {
            grades.Add(grade);
        }

        public Statistics GetStatistics()
        {
            var result = new Statistics();
            result.average = 0.0;
            result.low = double.MaxValue;
            result.high = double.MinValue;
            var sum = new double();

            foreach(var grade in grades)
            {
                result.high = Math.Max(result.high, grade);
                result.low = Math.Min(result.low, grade);
                sum += grade;
            }

            result.average = sum/grades.Count;

            return result;
        }

        private List<double> grades;
        public string Name;
    }
}