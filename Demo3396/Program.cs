namespace Demo3396;

class Program
{
    public static int MinimumOperations(int[] nums)
    {
        int a = 0;
        int c = nums.Length;
        while (c > 2)
        {
            a++;
            c -= 3;
        }

        var set = new HashSet<int>();
        
        int left = nums.Length - c, right = nums.Length - 1;
        for (int i = left; i <= right; i++)
        {
            if(!set.Add(nums[i])) return a + 1;
        }

        for (int i = 1; i <= a; i++)
        {
            for (int j = left - 3 * i; j < left - 3 * (i - 1); j++)
            {
                if(!set.Add(nums[j])) return a + 1 -i;
            }
        }
        
        return 0;
    }
    
    static void Main(string[] args)
    {
        int[] nums =
            [1, 2, 3, 4, 2, 3, 3, 5, 7];

        Console.WriteLine(MinimumOperations(nums));
    }
}
