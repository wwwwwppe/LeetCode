namespace Demo643;

class Program
{
    public static double FindMaxAverage(int[] nums, int k)
    {
        double max = 0;
        int sum = 0;
        for (var i = 0; i < k; i++)
        {
           sum += nums[i];     
        }
        max = (double)sum / k;
        int left = 0, right = k;
        while (right < nums.Length)
        {
            sum += nums[right];
            sum -= nums[left];
            max = Math.Max(max, (double)sum / k);
            right++;
            left++;
        }
        return max;
    }
    
    static void Main(string[] args)
    {
        int[] nums = [1, 12, -5, -6, 50, 3];
        int k = 4;
        FindMaxAverage(nums, k);
        Console.WriteLine("Hello, World!");
    }
}