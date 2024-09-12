namespace Demo2740;

class Program
{
    public int FindValueOfPartition(int[] nums)
    {
        int ret = int.MaxValue;
        Array.Sort(nums);
        for (var i = 0; i < nums.Length - 1; i++)
        {
            ret = Math.Min(ret, nums[i + 1] - nums[i]);
        }

        return ret;
    }
    
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
    }
}