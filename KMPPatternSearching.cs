namespace Knuth_Morris_Pratt
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string text = "AABAACAADAABAABA";
            string pattern = "AABA";

            Console.WriteLine(text);
            Console.WriteLine(pattern);

            KMPSearch(pattern, text);
        }

        static void KMPSearch(string pattern, string text)
        {
            int tLength = text.Length;
            int pLength = pattern.Length;

            if (pLength == 0 || tLength == 0 || pLength > tLength)
                return;

            int[] lps = ComputeLPS(pattern);

            int i = 0;
            int j = 0; 

            while (i < tLength)
            {
                if (pattern[j] == text[i])
                {
                    i++;
                    j++;
                }

                if (j == pLength)
                {
                    Console.WriteLine((i - j));
                    j = lps[j - 1];
                }
                else if (i < tLength && pattern[j] != text[i])
                {
                    if (j != 0)
                        j = lps[j - 1];
                    else
                        i++;
                }
            }
        }

        static int[] ComputeLPS(string pattern)
        {
            int length = pattern.Length;
            int[] lps = new int[length];
            int len = 0;
            int i = 1;

            while (i < length)
            {
                if (pattern[i] == pattern[len])
                {
                    len++;
                    lps[i] = len;
                    i++;
                }
                else
                {
                    if (len != 0)
                    {
                        len = lps[len - 1];
                    }
                    else
                    {
                        lps[i] = 0;
                        i++;
                    }
                }
            }

            return lps;
        }
    }
}
