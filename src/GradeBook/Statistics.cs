using System;

namespace GradeBook
{
    public class Statistics
    {
        public double average
        {
            get
            {
                return sum / count;
            }
        }
        double sum;
        int count;
        public double high;
        public double low;
        public char letter
        {
            get
            {
                switch (average)
                {
                    case var d when d >= 90.0:
                        return 'A';
                    case var d when d >= 80.0:
                        return 'B';
                    case var d when d >= 70.0:
                        return 'C';
                    case var d when d >= 60.0:
                        return 'D';
                    default:
                        return 'F';
                }
            }
        }

        public Statistics()
        {
            sum = 0.0;
            low = double.MaxValue;
            high = double.MinValue;
            count = 0;
        }

        public void UpdateStatistics(double grade)
        {
            high = Math.Max(high, grade);
            low = Math.Min(low, grade);
            sum += grade;
            count++;
        }
    }
}