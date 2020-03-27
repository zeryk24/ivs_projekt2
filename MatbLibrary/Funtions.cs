using System;
using System.Collections.Generic;
using System.Text;

namespace MatbLibrary
{
    public static class Functions
    {
        public static int Add(int x, int y)
        { 
            return x + y;
        }
        public static int Sub(int x, int y)
        {
            return x - y;
        }
        public static int Mul(int x, int y)
        {
            return x * y;
        }
        public static int Div(int x, int y)
        {
            try
            {
                 return x / y;
            }
            catch (DivideByZeroException)
            {
                throw;
            }
        }
    }
}
