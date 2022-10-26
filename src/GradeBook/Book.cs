using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GradeBook
{
    public delegate void gradeBookDelegate(Object sender, EventArgs args);
    public class NamedObject
    {
        public NamedObject(string name)
        {
            Name = name;
        }

        public String Name { set; get; }

    }

    public interface IBook
    {
        void AddGrade(double grade);
        Statistics getStatistics();
        String Name { get; }
        event gradeBookDelegate gradeAdded;

    }
    public abstract class Book : NamedObject, IBook
    {
        protected Book(string name) : base(name)
        {
        }

        public abstract event gradeBookDelegate gradeAdded;

        public abstract void AddGrade(double grade);
        public abstract Statistics getStatistics();

        /*public virtual Statistics getStatistics()
        {
            throw new NotImplementedException();
        }*/
    }

    public class DiskBook : Book  //,IDisposable
    {
        public DiskBook(string name) : base(name)
        {
        }

        public override event gradeBookDelegate gradeAdded;

        public override void AddGrade(double grade)
        {
            //open a file with same name of book and and put in it grade value  
            using (var writer = File.AppendText($"{Name}.txt"))
            {
                writer.WriteLine(grade);
                if (gradeAdded != null)
                {
                    gradeAdded(this, new EventArgs());
                }

            }

        }

        public override Statistics getStatistics()
        {
            var result = new Statistics();
            using (var reader = File.OpenText($"{Name}.txt"))
            {
                var line = reader.ReadLine();
                while (line != null)
                {
                    var number = double.Parse(line);
                    result.add(number);
                    line = reader.ReadLine();
                }

            }
            return result;
        }
    }//end of DiskBook


    public class InMemoryBook : Book
    {
        public InMemoryBook(string name) : base(name)
        {
            //grades = new List<double>() { 9, 900.7, 6.8 };
            grades = new List<double>();
            category = "sport";
        }
        public override void AddGrade(double grade)
        {
            if (grade <= 100 && grade >= 0)
            {
                this.grades.Add(grade);

                if (gradeAdded != null)
                {
                    gradeAdded(this, new EventArgs());

                }
            }
            else
            {
                throw new ArgumentException($"Invalid grade {nameof(grade)}");
            }

        }
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
        public override event gradeBookDelegate gradeAdded;
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
        public override Statistics getStatistics()
        {
            var result = new Statistics();
            for (var index = 0; index < grades.Count; index++)
            {
                result.add(grades[index]);

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
        public const string CATEGORY = "Tech";
        readonly string category = "math";
    }//end of InMemoryBook
}