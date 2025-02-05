namespace Counting_sort
{
    internal class Program
    {
        static void Main()
        {
            int[] numbers = { 11, 43, 9, 8, 3, 3 ,3 ,31 , 5, 6, 4 };

            PrintArray(numbers);

            int[] sortedNumbers = CountingSort(numbers);

            PrintArray(sortedNumbers);
        }

        static int[] CountingSort(int[] numbers)
        {
            int max = FindMax(numbers);
            int min = FindMin(numbers);
            int range = max - min + 1;

            int[] c = new int[range]; 
            int[] output = new int[numbers.Length]; 

            for (int i = 0; i < numbers.Length; i++)
            {
                c[numbers[i] - min]++;
            }

            for (int i = 1; i < range; i++)
            {
                c[i] += c[i - 1];
            }

            for (int i = numbers.Length - 1; i >= 0; i--)
            {
                output[c[numbers[i] - min] - 1] = numbers[i];
                c[numbers[i] - min]--;
            }

            return output;
        }

        static int FindMax(int[] numbers)
        {
            int max = numbers[0];
            for (int i = 1; i < numbers.Length; i++)
            {
                if (numbers[i] > max)
                {
                    max = numbers[i];
                }
            }
            return max;
        }

        static int FindMin(int[] numbers)
        {
            int min = numbers[0];
            for (int i = 1; i < numbers.Length; i++)
            {
                if (numbers[i] < min)
                {
                    min = numbers[i];
                }
            }
            return min;
        }

        static void PrintArray(int[] numbers)
        {
            for (int i = 0; i < numbers.Length; i++)
            {
                Console.Write(numbers[i] + " ");
            }
            Console.WriteLine();
        }
    }
}
