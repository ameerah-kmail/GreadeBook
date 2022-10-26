using System;
using System.Collections.Generic;

namespace GradeBook
{

    class Program
    {
static void Main(String[] args)
        {
            /*IBook book = new InMemoryBook("math");
            book.gradeAdded += OnGradeAdded;
            book.gradeAdded += OnGradeAdded;
            book.gradeAdded -= OnGradeAdded;
            book.gradeAdded += OnGradeAdded;*/
            //book.AddGrade(10);

            IBook book = new DiskBook("math");
     
            book.gradeAdded += OnGradeAdded;
            var done = false;
            done = EnteredGrades(book, done);

            
            //var input=Console.ReadLine();
            //var grade=double.Parse(input);


            //List<double> grades = new List<double>() { 9, 900.7, 6.8 };
            // book.showStatistics();

            /*           List<double> grades = new List<double>(){9,900.7,6.8};
                         var gg=new List<double>(){9,900.7,6.8};
                         grades.Add(8.9);
                         grades.Add(8);
                         var result=0.0;
                         foreach(var item in grades){
                             result+=item;
                         }
                         Console.WriteLine($"hi this the result {(result/grades.Count):N2}");//n2 that mean number of digits
                         var arrey = new double[10];
                         if (args.Length > 0)
                         {
                             Console.WriteLine($"Hello, {args[0]}!");
                         }
                         else
                             Console.WriteLine("Hello!");//cw  
             */

            var stats = book.getStatistics();

            //book.Name = "aaa";
            Console.WriteLine(book.Name);
            Console.WriteLine(InMemoryBook.CATEGORY);

            Console.WriteLine($"the low Grade is {stats.Low}");
            Console.WriteLine($"the high Grade is {stats.High}");
            Console.WriteLine($"the Average Grade is {stats.Average}");
            Console.WriteLine($"the letter Grade is {stats.Letter}");

            //book.longRunning(CallbackBook);
        }

        private static bool EnteredGrades(IBook ? book, bool done)
        {
            while (!done)
            {
                Console.WriteLine("Enter a grade or q to quit...");
                var input = Console.ReadLine();

                if (input == "q")
                {
                    done = true;
                    continue;
                }
                try
                {
                    var grade = double.Parse(input);
                    book.AddGrade(grade);
                }
                catch (ArgumentException exception)
                {
                    Console.WriteLine(exception.Message);

                }
                catch (Exception exception)
                {
                    Console.WriteLine(exception.Message);

                }
                finally
                {
                    Console.WriteLine("finally");
                }

            }

            return done;
        }

        static void CallbackBook(int i)
        {
            Console.WriteLine(i);
        }

        static void OnGradeAdded(object sender, EventArgs args)
        {
            Console.WriteLine("a grade is added");

        }
    }
}



