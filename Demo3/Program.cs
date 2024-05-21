using System.Collections;

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
        if (s.Length == 0) return 0;
        int retMax = 1;
        Queue<char> queue = new Queue<char>();
        foreach (var c in s)
        {
            if (queue.Contains(c))
            {
                while (queue.Count != 0 && queue.Contains(c))
                {
                    queue.Dequeue();
                }
            }
            else
            {
                //因为当前的这个验证为不等的，而且现在这个数没有在队列中，所以要将数量+1
                retMax = Math.Max(retMax, queue.Count + 1);
            }
            queue.Enqueue(c);
        }

        return retMax;
    }

    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
    }
}