namespace Demo1456;

class Program
{
    public int MaxVowels(string s, int k) {
        int left  = 0, right = k;
        HashSet<char> vowels = ['a', 'e', 'i', 'o', 'u'];
        int max = 0;
        int result = 0;
        for (int i = 0; i < k; i++)
        {
            if(vowels.Contains(s[i])) max++;
        }

        result = max;
        while (right < s.Length)
        {
            if (vowels.Contains(s[right])) max++;
            if (vowels.Contains(s[left])) max--;
            result = Math.Max(result, max);
            right++;
            left++;
        }
        return result;
    }
    
    static void Main(string[] args)
    {
        PerfBench.Run();
    }
}