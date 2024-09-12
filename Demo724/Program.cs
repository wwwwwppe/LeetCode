namespace Demo724;

class Program
{
    public int PivotIndex(int[] nums)
    {
        var sum = nums.Sum();
        int preSum = 0;
        for (var i = 0; i < nums.Length; i++)
        {
            if (preSum == sum - preSum - nums[i])
            {
                return i;
            }
            preSum += nums[i];
        }

        return -1;
    }
    
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
    }
}