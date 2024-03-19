namespace Demo2369;

class Program
{
    public bool ValidPartition(int[] nums)
    {
        int n = nums.Length;
        bool[] dp = new bool[n + 1];
        dp[0] = true;
        for (var i = 2; i <= n; i++)
        {
            dp[i] = dp[i - 2] && validTwo(nums[i - 1], nums[i - 2]);
            if (i >= 3)
            {
                dp[i] = dp[i] || (dp[i - 3] && validThree(nums[i - 3], nums[i - 2], nums[i - 1]));
            }
        }

        return dp[n];
    }

    public bool validTwo(int num1, int num2)
    {
        return num1 == num2;
    }

    public bool validThree(int num1, int num2, int num3)
    {
        return (num1 == num2 && num2 == num3) || (num1 + 1 == num2 && num2 + 1 == num3);
    }

    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
    }
}