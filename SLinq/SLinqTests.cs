using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace SLinq
{
    public class SLinqTests
    {
        private static readonly string[] data = new string[] { "one", "two", "three", null };
        private static readonly string[] empty = new string[0];


        public static void TestContains()
        {
            string expected = null;
            var contains = data.Contains(expected);
            Debug.Assert(contains, string.Format("Contains for data should return true for {0}", expected));

            Console.WriteLine("Contains test passed.");
        }

        public static void TestCount()
        {
            var count = data.Count();
            var expectedCount = data.GetLength(0);
            Debug.Assert(count == expectedCount, string.Format("count of data should be {0}", expectedCount));

            Console.WriteLine("Count test passed.");
        }

        public static void TestFirst()
        {
            var first = data.First();
            Debug.Assert(first == data[0], string.Format("First of data should be {0}", data[0]));

            try
            {
                empty.First();
                Debug.Assert(false, "First of empty should throw");
            }
            catch (InvalidOperationException)
            {
                // Fails as expected
            }

            Console.WriteLine("First test passed.");
        }

        public static void TestFirstOrDefault()
        {
            var first = empty.FirstOrDefault();
            Debug.Assert(first == null, "FirstOrDefault should be default of type");

            first = data.FirstOrDefault();
            Debug.Assert(first == data[0], string.Format("FirstOrDefault of data should be {0}", data[0]));

            Console.WriteLine("FirstOrDefault test passed.");
        }

        public static void TestLast()
        {
            var last = data.Last();
            Debug.Assert(last == data[data.Length - 1], string.Format("Last of data should be {0}", data[data.Length - 1]));

            try
            {
                empty.Last();
                Debug.Assert(false, "Last of empty should throw");
            }
            catch (InvalidOperationException)
            {
                // Fails as expected
            }

            Console.WriteLine("Last test passed.");
        }

        public static void TestLastOrDefault()
        {
            var last = empty.LastOrDefault();
            Debug.Assert(last == null, "LastOrDefault should be default of type");

            last = data.LastOrDefault();
            Debug.Assert(last == data[data.Length - 1], string.Format("LastOrDefault of data should be {0}", data[data.Length - 1]));

            Console.WriteLine("LastOrDefault test passed.");
        }

        public static void TestSkip()
        {
            var dataCount = data.Count();
            for (int i = 0; i < 5; i++)
            {
                var amt = i;
                var filtered = data.Skip(amt).Count();
                var expected = dataCount - Math.Min(amt, dataCount);
                Debug.Assert(filtered == expected, string.Format("Skip from data should equal {0}, actual {1}", expected, filtered));
            }

            Console.WriteLine("Skip test passed.");
        }

        public static void TestTake()
        {
            for (int i = 0; i < 5; i++)
            {
                var amt = i;
                var filtered = data.Take(amt).Count();
                var expected = Math.Min(amt, data.Count());
                Debug.Assert(filtered == expected, string.Format("Take from data should equal {0}, actual {1}", expected, filtered));
            }

            Console.WriteLine("Take test passed.");
        }

        public static void TestWhere()
        {
            var filtered = data.Where(x => x == "one" || x == "two").Count();

            Debug.Assert(filtered == 2, string.Format("Take from data should equal {0}, actual {1}", 2, filtered));

            Console.WriteLine("Where test passed.");
        }
    }
}
