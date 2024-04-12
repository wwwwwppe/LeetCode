namespace Demo485;

class Program
{
    public int FindMaxConsecutiveOnes(int[] nums)
    {
        int retMax = 0;
        int max=0;
        for (var i = 0; i < nums.Length; i++)
        {
            if (nums[i] == 1) max++;
            else
            {
                if (retMax < max) retMax = max;
                max = 0;
            }
        }

        return retMax > max ?retMax: max;
    }
    
    public int FindMaxConsecutiveOnes2(int[] nums)
    {
        return nums.Aggregate(new {
                Count = 0,
                Max = 0
            }, (a, n) => n == 1 ?
                new { Count = a.Count + 1, Max = Math.Max(a.Count + 1, a.Max) } :
                new { Count = 0, Max = a.Max })
                .Max;
    }

    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
    }
}