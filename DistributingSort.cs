namespace Distributing_sort
{
    internal class Program
    {
        static void Main()
        {
            double[] numbers = { 0.78, 0.17, 0.39, 0.26, 0.72, 0.94, 0.21, 0.12, 0.23, 0.68 };
;
            PrintArray(numbers);

            BucketSort(numbers);

            PrintArray(numbers);
        }

        static void BucketSort(double[] numbers)
        {
            int n = numbers.Length;

            //listával egyszerűbb az implementáció
            List<double>[] buckets = new List<double>[n];
            for (int i = 0; i < n; i++)
            {
                buckets[i] = new List<double>();
            }

            for (int i = 0; i < n; i++)
            {
                int bucketIndex = (int)(numbers[i] * n);
                buckets[bucketIndex].Add(numbers[i]);
            }

            for (int i = 0; i < n; i++)
            {
                buckets[i].Sort();
            }

            int k = 0;
            for (int i = 0; i < n; i++)
            {
                foreach (double value in buckets[i])
                    numbers[k++] = value;
            }
        }

        static void PrintArray(double[] numbers)
        {
            for (int i = 0; i <= numbers.Length; i++)
            {
                Console.Write(numbers[i] + " ");
            }
            Console.WriteLine();
        }
    }
}
