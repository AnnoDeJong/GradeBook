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

        public void AddLetterGrade(char letter)
        {
            switch(letter)
            {
                case 'A':
                    AddGrade(90);
                    break;
                case 'B':
                    AddGrade(80);
                    break;
                case 'C':
                    AddGrade(70);
                    break;
                
                default:
                    AddGrade(0);
                    break;
            }
        }
        public void AddGrade(double grade)
        {
            if(grade <= 100 && grade >= 0)
            {
                grades.Add(grade);
            }
            else
            {
                throw new ArgumentException($"Invalid {nameof(grade)}: {grade}");
            }
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

            switch(result.average)
            {
                case var d when d >= 90.0:
                    result.letter = 'A';
                    break;
                case var d when d >= 80.0:
                    result.letter = 'B';
                    break;
                case var d when d >= 70.0:
                    result.letter = 'C';
                    break;
                case var d when d >= 60.0:
                    result.letter = 'D';
                    break;
                default:
                    result.letter = 'F';
                    break;
            }
            return result;
        }

        public bool GradeExists(double grade)
        {
            if(grades.Count == 0)
            {
                return false;
            }
            else
            {
                foreach(var gradeValue in grades)
                {
                    if(gradeValue == grade)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        private List<double> grades;
        public string Name;
    }
}