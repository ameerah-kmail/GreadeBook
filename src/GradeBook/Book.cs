using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GradeBook
{
    public delegate void gradeBookDelegate(Object sender, EventArgs args);
    public class Book
    {
        public Book()
        {
            //grades = new List<double>() { 9, 900.7, 6.8 };
            grades = new List<double>();
            category = "sport";
        }
        public void AddGrade(double grade)
        {
            if (grade <= 100 && grade >= 0)
            {
                this.grades.Add(grade);

                if (gradeAdded != null)
                {
                    gradeAdded(this,new EventArgs());

                }
            }
            else
            {
                throw new ArgumentException($"Invalid grade {nameof(grade)}");
            }

        }
        public event gradeBookDelegate gradeAdded;
        public void AddGrade(char letter)
        {
            switch (letter)
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

            /*foreach (var item in grades)
            {
                result.Low = Math.Min(item, result.Low);
                result.High = Math.Max(item, result.High);
                result.Average += item;
            }*/
            //var index = 0;
            /* do
             {
                 result.Low = Math.Min(grades[index], result.Low);
                 result.High = Math.Max(grades[index], result.High);
                 result.Average += grades[index];
                 index++;
             } while(index < grades.Count);*/

            /*while (index < grades.Count)
            {
                result.Low = Math.Min(grades[index], result.Low);
                result.High = Math.Max(grades[index], result.High);
                result.Average += grades[index];
                index++;
            };*/

            for (var index = 0; index < grades.Count; index++)
            {
                // if (grades[index] == 9)
                //break;
                //continue;
                //goto done;

                result.Low = Math.Min(grades[index], result.Low);
                result.High = Math.Max(grades[index], result.High);
                result.Average = result.Average + grades[index];
            }

            result.Average = result.Average / grades.Count;

            switch (result.Average)
            {
                case var letter when letter >= 90:
                    result.Letter = 'A';
                    break;

                case var letter when letter >= 80:
                    result.Letter = 'B';
                    break;

                case var letter when letter >= 70:
                    result.Letter = 'C';
                    break;

                default:
                    result.Letter = 'F';
                    break;

            }

            //done:
            return result;
        }

        private List<double> grades;

        /* public String Name
         {
             get
             {
                 return name.ToUpper();

             }
             set
             {
                 if (!String.IsNullOrEmpty(value))
                 {
                     name = value;
                 }
             }
         }
         private String name;*/

        //  public String Name {private set; get;} 

        public delegate void CallbackMain(int i);//-->Delegate 

        public void longRunning(CallbackMain obj)
        {
            for (int i = 0; i < 10; i++)
                obj(i);
        }//-->
        public String Name { set; get; }
        public const string CATEGORY = "Tech";
        readonly string category = "math";


    }
}