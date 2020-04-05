using System;
using System.Collections.Generic;
using System.Text;

namespace MatbLibrary
{
    public static class Functions
    {
        public static double Add(double x, double y)
        { 
            return x + y;
        }
        public static double Sub(double x, double y)
        {
            return x - y;
        }
        public static double Mul(double x, double y)
        {
            return x * y;
        }
        public static double Div(double x, double y)
        {
            if (y == 0)
                throw new DivideByZeroException("Error: cannot divide by zero");
            return x / y;
        }
        public static double Fact(double x)
        {
            if (x < 0 || x % 1 != 0)
                throw new ArgumentException("Error: invalid argument");
            if (x == 0)
                return 1;
            double sum;
            for (sum = 1; x > 0; x--)
            {
                sum *= x;
            }
            return sum;
        }
        public static double Exp(double x, double y)
        {
            if (y % 1 != 0)
                throw new ArgumentException("Error: invalid argument");
            if (y == 0)
                return 1;
            bool isNegative;
            if (y < 0)
            {
                isNegative = true;
                y = Math.Abs(y);
            }
            else
                isNegative = false;
            double sum = 1;
            for(; y > 0; y--)
            {
                sum *= x;
            }
            if (isNegative == true)
                sum = 1 / sum;
            return sum;
        }
        //nth root algorithm using Newthon's method
        public static double Root(double x, double y)
        {
            if (y == 0 || y % 1 != 0 || (x < 0 && y % 2 == 0))
                throw new ArgumentException("Error: invalid argument");

            Random rand = new Random();
            double xPrev = rand.Next(10);
            double diff = int.MaxValue;
            double xNext = 0.0;
            while (diff > 1e-12)
            {
                xNext = ((y - 1.0) * xPrev + x / Functions.Exp(xPrev, y - 1)) / y;
                diff = Math.Abs(xNext - xPrev);
                xPrev = xNext;
            }

            return xNext;
        }
        //NatLog using Taylor series
        public static double NatLog(double x)
        {
            if (x <= 0)
                throw new ArgumentException("Error: invalid argument");
            double sum = 0.0;
            double term_0 = (x - 1) / (x + 1);
            double term = term_0;
            double tmp = term;
            double divBy = 1.0;
            while (Math.Abs(tmp) > 1e-12)
            {
                sum += tmp;
                term *= term_0 * term_0;
                divBy += 2;
                tmp = term / divBy;
            }
            return (2 * sum);
        }
    }
}
