using System;
using System.Collections.Generic;
using System.Text;

namespace DelegateDemo
{
    delegate int MathOperation(int a, int b);
    public class delegateDemo
    {
        public static int Add(int a, int b)
        {
            return a + b;
        }
        public static int Subtract(int a, int b)
        {
            return a - b;
        }
        public static int Multiply(int a, int b)
        {
            return a * b;
        }
    }
}