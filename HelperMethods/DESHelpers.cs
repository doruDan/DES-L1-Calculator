using System;

namespace DES_L1_Calculator.HelperMethods
{
    internal class DESHelpers
    {
        static readonly int[] InitialPermutationTable =
        {
            57, 49, 41, 33, 25, 17,  9, 1,
            59, 51, 43, 35, 27, 19, 11, 3,
            61, 53, 45, 37, 29, 21, 13, 5,
            63, 55, 47, 39, 31, 23, 15, 7,
            56, 48, 40, 32, 24, 16,  8, 0,
            58, 50, 42, 34, 26, 18, 10, 2,
            60, 52, 44, 36, 28, 20, 12, 4,
            62, 54, 46, 38, 30, 22, 14, 6
        };

        public static string ApplyInitialPermutation(string binaryInput)
        {
            if (binaryInput.Length != 64)
            {
                throw new ArgumentException("Input must be exactly 64 bits.");
            }

            char[] permutedChars = new char[64];

            for (int i = 0; i < 64; i++)
            {
                int targetIndex = InitialPermutationTable[i];
                permutedChars[i] = binaryInput[targetIndex];
            }

            return new string(permutedChars);
        }

        public static void PrintIPTable()
        {
            Console.WriteLine("--- Initial Permutation (IP) Table ---");
            for (int i = 0; i < InitialPermutationTable.Length; i++)
            {
                // Add 1 when printing so it matches the official 1-based DES documentation
                Console.Write($"{InitialPermutationTable[i] + 1} ");
                if ((i + 1) % 8 == 0) Console.WriteLine(); // New line every 8 numbers
            }
            Console.WriteLine("\n");
        }
    }
}
