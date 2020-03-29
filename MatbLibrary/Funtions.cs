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
            return 1;
        }
        public static double Exp(double x, double y)
        {
            return 1;
        }
        public static double Root(double x, double y)
        {
            return 1;
        }
        public static double NatLog(double x)
        {
            return 1;
        }
    }
}
