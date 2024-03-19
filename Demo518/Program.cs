namespace Demo518;

class Program
{
    public int Change(int amount, int[] coins) {
        int[] dp = new int[amount + 1];
        dp[0] = 1;
        //将coins放在外面是因为最后的结果是可以重复的。放外面循环相当于将coins从大到小的一种排序。
        foreach (var coin in coins)
        {
            for (int i = coin; i <= amount; i++)
            {
                dp[i] += dp[i - coin];
            }
        }

        return dp[amount];
    }
    
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
    }
}