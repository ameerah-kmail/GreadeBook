using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GradeBook
{
    public class Statistics
    {
        public double Average
        {//readonly prop
            get
            {
                return Sum / Count;
            }

        }
        public double High;
        public double Low;
        public char Letter
        {
            get
            {
                switch (Average)
                {
                    case var letter when letter >= 90:
                        return 'A';

                    case var letter when letter >= 80:
                        return 'B';
                        
                    case var letter when letter >= 70:
                        return 'C';
                        
                    default:
                        return 'F';
                        
                }

            }

        }
        public double Sum;
        public int Count;

        public void add(double number)
        {
            Sum += number;
            Count++;
            Low = Math.Min(number, Low);
            High = Math.Max(number, High);
        }
        public Statistics()
        {
            Sum = 0.0;
            Count = 0;
            Low = double.MaxValue;
            High = double.MinValue;
        }
    }
}