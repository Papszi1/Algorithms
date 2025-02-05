namespace QuickSearch
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string text = "AABAACAADAABAABA";
            string pattern = "AABA";

            Console.WriteLine(text);
            Console.WriteLine(pattern);

            QuickSearch(text, pattern);
        }

        static void QuickSearch(string text, string pattern)
        {
            int tLength = text.Length;
            int pLength = pattern.Length;

            if (pLength == 0 || tLength == 0 || pLength > tLength)
                return;

            int[] shiftTable = new int[256]; 

            for (int k = 0; k < 256; k++)
                shiftTable[k] = pLength + 1;

            for (int k = 0; k < pLength; k++)
                shiftTable[(int)pattern[k]] = pLength - k;

            int i = 0; 
            while (i <= tLength - pLength)
            {
                int j = 0;
                while (j < pLength && text[i + j] == pattern[j])
                    j++;

                if (j == pLength)
                    Console.WriteLine(i);

                if (i + pLength < tLength)
                    i += shiftTable[(int)text[i + pLength]];
                else
                    break;
            }
        }
    }
}
