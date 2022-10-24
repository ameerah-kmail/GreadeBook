using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GradeBook
{
    public class Book
    {
        public Book()
        {
            grades = new List<double>() { 9, 900.7, 6.8 };
        }
        public void AddGrade(double grade)
        {
            this.grades.Add(grade);
        }
        public void showStatistics()
        {
            //throw new NotImplementedException();
            var lowGrade = double.MaxValue;
            var highGrade = double.MinValue;

            foreach (var item in grades)
            {
                lowGrade = Math.Min(item, lowGrade);
                highGrade = Math.Max(item, highGrade);
            }
            Console.WriteLine($"the lowGrade {lowGrade}");
            Console.WriteLine($"the highGrade {highGrade}");
        }

        public Statistics getStatistics()
        {
            //throw new NotImplementedException();
            var result = new Statistics();
            result.Average = 0.0;
            result.Low = double.MaxValue;
            result.High = double.MinValue;

            foreach (var item in grades)
            {
                result.Low = Math.Min(item, result.Low);
                result.High = Math.Max(item, result.High);
                result.Average += item;
            }
            result.Average /= grades.Count;
            return result;
        }
        private List<double> grades;

    }
}