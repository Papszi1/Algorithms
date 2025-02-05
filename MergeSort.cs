using System;

namespace MergeSort
{
    internal class Program
    {
        static void Main()
        {
            Console.WriteLine("Hello World!");

            int[] numbers = { 25, 18, 32, 32, 38, 34, 43 };
            PrintNumbers(numbers);

            MergeSort(numbers, 0, numbers.Length - 1);

            PrintNumbers(numbers);
        }

        static void MergeSort(int[] numbers, int l, int r)
        {
            if (l < r)
            {
                int mid = (l + r) / 2;

                MergeSort(numbers, l, mid);
                MergeSort(numbers, mid + 1, r);

                Merge(numbers, l, mid, r);
            }
        }

        static void Merge(int[] numbers, int l, int mid, int r)
        {
            int lSize = mid - l + 1;
            int rSize = r - mid;

            int[] lArray = new int[lSize];
            int[] rArray = new int[rSize];

            for (int i = 0; i < lSize; i++)
                lArray[i] = numbers[l + i];

            for (int i = 0; i < rSize; i++)
                rArray[i] = numbers[mid + 1 + i];

            int lIndex = 0;
            int rIndex = 0;
            int mIndex = l;

            while (lIndex < lSize && rIndex < rSize)
            {
                if (lArray[lIndex] <= rArray[rIndex])
                    numbers[mIndex++] = lArray[lIndex++];
                else
                    numbers[mIndex++] = rArray[rIndex++];
            }

            while (lIndex < lSize)
                numbers[mIndex++] = lArray[lIndex++];

            while (rIndex < rSize)
                numbers[mIndex++] = rArray[rIndex++];
        }

        static void PrintNumbers(int[] numbers)
        {
            for (int i = 0; i < numbers.Length; i++)
            {
                Console.Write(numbers[i] + " ");
            }
            Console.WriteLine();
        }
    }
}
