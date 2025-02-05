namespace QuickSort
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            int[] numbers = new int[] { 25, 18, 32, 32, 38, 34, 43 };

            PrintNumbers(numbers);

            QuickSort(numbers);

            PrintNumbers(numbers);
        }

        static void QuickSort(int[] numbers)
        {
            quickSort(numbers, 0, numbers.Length - 1);
        }

        static void quickSort(int[] numbers, int p, int r)
        {
            if (p < r)
            {
                int q = Partition(numbers, p, r);
                quickSort(numbers, p, q - 1);
                quickSort(numbers, q + 1, r);
            }
        }

        static int Partition(int[] numbers, int p, int r)
        {
            Random random = new Random();
            int pivotIndex = random.Next(p, r + 1);  
            int pivot = numbers[pivotIndex];

            (numbers[pivotIndex], numbers[r]) = (numbers[r], numbers[pivotIndex]);

            int i = p - 1;

            for (int j = p; j < r; j++)
            {
                if (numbers[j] <= pivot)
                {
                    i++;
                    (numbers[i], numbers[j]) = (numbers[j], numbers[i]);
                }
            }

            (numbers[i + 1], numbers[r]) = (numbers[r], numbers[i + 1]); 

            return i + 1;
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
