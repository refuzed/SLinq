using System;
using System.Collections.Generic;

namespace SLinq
{
    class Program
    {
        static void Main(string[] args)
        {
            SLinqTests.TestContains();
            SLinqTests.TestCount();
            SLinqTests.TestFirst();
            SLinqTests.TestFirstOrDefault();
            SLinqTests.TestLast();
            SLinqTests.TestLastOrDefault();
            SLinqTests.TestSkip();
            SLinqTests.TestTake();
            SLinqTests.TestWhere();

            Console.ReadKey();
        }
    }
}
