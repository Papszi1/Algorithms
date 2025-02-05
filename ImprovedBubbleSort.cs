namespace ImprovedBubbleSort
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            int[] numbers = new int[] { 34, 32, 25, 18, 43, 38, 32 };

            PrintNumbers(numbers);

            ImprovedBubbleSort(numbers);

            PrintNumbers(numbers);

        }

        static void ImprovedBubbleSort(int[] numbers)
        {
            int lastChanged = numbers.Length;
            for (int j = 0; j < lastChanged; j++)
            {
                lastChanged = 0;
                for (int i = 0; i < numbers.Length - 1 - j; i++)
                {
                    if (numbers[i] > numbers[i+1])
                    {
                        int temp = numbers[i];
                        numbers[i] = numbers[i + 1];
                        numbers[i + 1] = temp;

                        lastChanged = i;
                    }
                }
            }
        }


        static void PrintNumbers(int[] numbers)
        {
            for (int i = 0; i < numbers.Length; i++)
            {
                Console.Write(numbers[i]+ " ");
            }
            Console.WriteLine();
        }
    }
}
