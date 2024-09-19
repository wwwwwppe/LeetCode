namespace Demo2414;

class Program
{
    public int LongestContinuousSubstring(string s)
    {
        int left = 0,
            right = 1;
        int max = 1;
        var cs = s.ToCharArray();
        while (right < cs.Length)
        {
            if (cs[right] - cs[right-1] == 1)
            {
                max = Math.Max(max, right - left + 1);
            }
            else
            {
                left = right;
            }
            right++;
        }
        return max;
    }

    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
    }
}
