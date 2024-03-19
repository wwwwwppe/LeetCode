namespace Demo2789;

class Program
{
    public long MaxArrayValue(int[] nums)
    {
        if (nums.Length == 1) return nums[0];
        //滑动窗口
        int n = nums.Length;
        int right = n - 1, rightFast = n - 2;
        long max = nums[right];
        long sum = 0;
        while (rightFast>0)
        {
            sum += nums[rightFast];
            if (sum < nums[rightFast - 1])
            {
                sum =0;
                right = rightFast;
            }
            else
            {
                sum += nums[rightFast];
                max = Math.Max(max, sum);
            }

            rightFast--;
        }

        return max;
    }
    
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
    }
}