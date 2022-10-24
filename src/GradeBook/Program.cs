using System;
using System.Collections.Generic;

namespace GradeBook
{

    class Program
    {



        static void Main(String[] args)
        {
            var book = new Book();
            book.AddGrade(10);
            List<double> grades = new List<double>() { 9, 900.7, 6.8 };
            book.showStatistics();

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

        }
    }
}



