namespace Demo3;

class Program
{
    public int LengthOfLongestSubstring(string s)
    {
        if (s.Length==0)
        {
            return 0;
        }
        int max = 1;
        Queue<char> queue = new Queue<char>();
        for (var i = 0; i < s.Length; i++)
        {
            if (queue.Contains(s[i]))
            {
                while (queue.Count != 0 && queue.Contains(s[i]))
                {
                    queue.Dequeue();
                }
            }
            else
            {
                max = Math.Max(max, queue.Count + 1);
            }
            queue.Enqueue(s[i]);
        }

        return max;
    }

    public int LengthOfLongestSubstringNew(string s)
    {
        
    }

    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
    }
}