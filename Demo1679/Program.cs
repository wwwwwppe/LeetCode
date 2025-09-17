using System.Collections;

namespace Demo1679;

class Program
{
    public int MaxOperations(int[] nums, int k)
    {
        Dictionary<int, int> dic = new Dictionary<int, int>();
        int max = 0;
        foreach (var j in nums)
        {
            if (dic.ContainsKey(k - j))
            {
                dic[k - j]--;
                max++;
                if (dic[k - j] == 0)
                {
                    dic.Remove(k - j);
                }
            }
            else if (!dic.TryAdd(j, 1))
            {
                dic[j]++;
            }
        }

        return max;
    }

    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
    }
}