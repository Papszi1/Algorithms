namespace InsertionSort
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            int[] numbers = new int[] { 34, 32, 25, 18, 43, 38, 32 };

            PrintNumbers(numbers);

            InsertionSort(numbers);

            PrintNumbers(numbers);

        }

        static void InsertionSort(int[] numbers)
        {
            for (int i = 1; i < numbers.Length; i++)
            {
                if (numbers[i] < numbers[i - 1])
                {
                    int x = numbers[i];
                    numbers[i] = numbers[i - 1];
                    for (int j = i - 1; j >= 0; j --)
                    {
                        if (x < numbers[j])
                        {
                            numbers[j+1] = numbers[j];
                            numbers[j] = x;
                        }
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
