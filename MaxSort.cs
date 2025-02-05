namespace MaxSort
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            int[] numbers = new int[] { 34, 32, 25, 18, 43, 38, 32 };

            PrintNumbers(numbers);

            MaxSort(numbers);

            PrintNumbers(numbers);
        }

        static void MaxSort(int[] numbers)
        {
            for (int i = numbers.Length-1; i >= 0; i--)
            {
                int max = numbers[0];
                int maxI = 0;
                for (int j = 0; j <= i; j++)
                {
                    if (numbers[j] > max)
                    {
                        max = numbers[j];
                        maxI = j;
                    }      
                }
                numbers[maxI] = numbers[i];
                numbers[i] = max;
                PrintNumbers(numbers);
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
