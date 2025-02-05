using System.Globalization;

namespace Bubblesort
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = new int[] { 3, 1, 2, 5, 4, 2 };

            PrintNumbers(numbers);

            BubbleSort(numbers);

            PrintNumbers(numbers);
        }
        static void BubbleSort(int[] numbers)
        {
            for (int j = 0; j < numbers.Length; j++)
            {
                for (int i = 0; i < numbers.Length - 1 - j; i++)
                {
                    if (numbers[i] > numbers[i + 1])
                    {
                        int temp = numbers[i];
                        numbers[i] = numbers[i + 1];
                        numbers[i + 1] = temp;
                    }
                }
            }
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
