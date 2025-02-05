namespace BruteForce
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string text = "AABAACAADAABAABA";
            string pattern = "AABA";

            Console.WriteLine(text);
            Console.WriteLine(pattern);

            Search(text, pattern);
        }

        static void Search(string text, string pattern)
        {
            int tLength = text.Length;
            int pLength = pattern.Length;

            for (int i = 0; i <= tLength - pLength; i++)
            {
                int j;
                for (j = 0; j < pLength; j++)
                {
                    if (text[i + j] != pattern[j])
                        break;
                }

                if (j == pLength)
                    Console.WriteLine("Pattern starts at: " + i);
            }
        }
    }
}