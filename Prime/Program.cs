using System;

namespace Prime
{
    class Program
    {
        static void Main(string[] args)
        {
            // Test the corrected IsPrime function with a variety of examples
            int[] numbersToTest = {
                // Edge cases and non-primes <= 1
                -5, 0, 1,
                // Smallest primes
                2, 3, 5, 7, 11, 13, 17, 19,
                // Small composite numbers
                4, 6, 8, 9, 10, 12, 14, 15, 16, 18, 20, 21, 25,
                // Larger composite numbers
                91, // 7 * 13
                169, // 13 * 13
                221, // 13 * 17
                // A larger prime
                7919 // 1000th prime
            };

            Console.WriteLine("Testing the corrected IsPrime function using number theory principles:");
            foreach (int num in numbersToTest)
            {
                // Right-align the number for cleaner output
                Console.WriteLine($"{num,5} is prime? {IsPrime(num)}");
            }

            // Keep the console window open until user presses Enter
            Console.WriteLine("\nPress Enter to exit.");
            Console.ReadLine();
        }

        /// <summary>
        /// Determines if a given integer is a prime number using number theory principles,
        /// including optimised trial division (checking divisibility by 2, 3, and then
        /// numbers of the form 6k +/- 1 up to the square root).
        /// </summary>
        /// <param name="number">The integer to check.</param>
        /// <returns>True if the number is prime, False otherwise.</returns>
        public static bool IsPrime(int number)
        {
            // --- Principle 1: Definition of Prime ---
            // Prime numbers must be greater than 1.
            if (number <= 1)
            {
                return false;
            }

            // --- Principle 2: Small Primes ---
            // Handle the smallest primes 2 and 3 directly.
            if (number <= 3) // Covers number == 2 and number == 3
            {
                return true;
            }

            // --- Principle 3: Divisibility by 2 and 3 ---
            // Eliminate multiples of 2 and 3 early. If a number > 3 is divisible
            // by 2 or 3, it cannot be prime. This is based on the fact that
            // all primes > 3 are of the form 6k ± 1.
            if (number % 2 == 0 || number % 3 == 0)
            {
                return false;
            }

            // --- Principle 4: Trial Division Limit & 6k ± 1 Optimization ---
            // We only need to check divisibility up to the square root of the number.
            // Furthermore, we only need to check potential divisors of the form 6k ± 1,
            // since all other numbers are multiples of 2 or 3, which we've already excluded.
            // We start checking from 5.
            int limit = (int)Math.Sqrt(number);

            // Check numbers i = 5, 11, 17, ... (form 6k-1)
            // and i+2 = 7, 13, 19, ... (form 6k+1)
            for (int i = 5; i <= limit; i += 6)
            {
                if (number % i == 0 || number % (i + 2) == 0)
                {
                    // Found a divisor, so the number is not prime.
                    return false;
                }
            }

            // If the loop completes without finding any divisors, the number is prime.
            return true;
        }
    }
}
