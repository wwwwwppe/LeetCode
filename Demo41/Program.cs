namespace Demo41;

class Program
{
    public int FirstMissingPositive(int[] nums)
    {
        var b = nums.ToHashSet();

        for (var i = 1; i <= nums.Length+1; i++)
        {
            if (!b.Contains(i))
            {
                return i;
            }
        }

        return 0;
    }

    public int FirstMissingPositive1(int[] nums)
    {
        int n = nums.Length;
        for (var i = 0; i < nums.Length; i++)
        {
            if (nums[i] <= 0)
            {
                nums[i] = n + 1;
            }
        }

        for (int i = 0; i < n; i++)
        {
            int a = Math.Abs(nums[i]);
            if (a <= n)
            {
                nums[a-1] = -Math.Abs(nums[a-1]);
            }
        }

        for (int i = 0; i < n; i++)
        {
            if (nums[i] > 0)
                return i + 1;
        }

        return n + 1;
    }
    
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
    }
}