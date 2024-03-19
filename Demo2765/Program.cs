namespace Demo2765;

class Program
{
    public int AlternatingSubarray(int[] nums)
    {
        int left = 0, right = 1, demo = 0, max = -1;
        while (right < nums.Length)
        {
            int temp = nums[right] - nums[right - 1];
            if (demo == 0 && Math.Abs(temp) == 1 || Math.Abs(demo) == 1 && demo == -temp)
            {
                max = Math.Max(right - left + 1, max);
                demo = temp;
            }
            else if (Math.Abs(demo) == 1 && demo == temp)
            {
                left = right - 1;
                right--;
                demo = temp;
            }
            else
            {
                left = right;
                demo = 0;
            }
            right++;
        }
        return max;
    }

    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
    }
}