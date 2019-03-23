using System;
using System.Linq;
using MoreLinq;
using System.Collections.Generic;

namespace CodeCamp.ConsoleApp
{
    // Project Euler Problem 2
    // By considering the terms in the Fibonacci sequence whose values do not exceed four million, 
    // find the sum of the even-valued terms.
    class Program
    {
        static void Main(string[] args)
        {
            var sum = GetFibonacciSequence(4000000)
                .Where(e => e % 2 == 0)
                .Sum();

            Console.WriteLine($"The sum of even fibonnaci numbers up to 4M is {sum}");
        }

        private static IEnumerable<long> GetFibonacciSequence(long max)
        {
            long minusTwo = 0;
            long minusOne = 1;

            yield return minusTwo;
            yield return minusOne;

            while (minusOne <= max)
            {
                var next = minusTwo + minusOne;
                yield return next;
                minusTwo = minusOne;
                minusOne = next;
            }
        }
    }
}
