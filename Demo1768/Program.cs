using System.Text;

namespace Demo1768;

class Program
{
    public string MergeAlternately(string word1, string word2)
    {
        int left = 0,
            right = 0;
        int word1Length = word1.Length;
        int word2Length = word2.Length;
        StringBuilder s = new StringBuilder();
        for (int i = 0; i < word1.Length + word2.Length; i++)
        {
            if ((i % 2 == 0 && left < word1Length) || right >= word2Length)
            {
                s.Append(word1[left]);
                left++;
            }
            else if ((i % 2 == 1 && right < word2Length) || left >= word1Length)
            {
                s.Append(word2[right]);
                right++;
            }
        }
        return s.ToString();
    }

    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
    }
}
