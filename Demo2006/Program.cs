namespace Demo2006;

class Program
{
    public int CountKDifference(int[] nums, int k)
    {
        int ret = 0;
        Dictionary<int, int> dictionary = new Dictionary<int, int>();
        foreach (var num in nums)
        {
            int a;
            if (dictionary.TryGetValue(num - k, out a))
            {
                ret += a;
            }

            if (dictionary.TryGetValue(Math.Abs(num + k), out a))
            {
                ret += a;
            }

            if (!dictionary.TryAdd(num, 1))
            {
                dictionary[num] = ++dictionary[num];
            }
        }

        return ret;
    }

    public int CountKDifferenceOri(int[] nums, int k)
    {
        int a = 0;
        for (var i = nums.Length - 1; i >= 1; i--)
        {
            for (var i1 = i - 1; i1 >= 0; i1--)
            {
                if (Math.Abs(nums[i] - nums[i1]) == k) a++;
            }
        }

        return a;
    }

    static void Main(string[] args)
    {
        Program program = new Program();
        program.CountKDifference([7, 7, 8, 3, 1, 2, 7, 2, 9, 5], 6);
        Console.WriteLine("Hello, World!");
    }
}