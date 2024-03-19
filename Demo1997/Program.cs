﻿namespace Demo1997;

class Program
{
    public int FirstDayBeenInAllRooms(int[] nextVisit) {
        int mod = 1000000007;
        int len = nextVisit.Length;
        int[] dp = new int[len];

        dp[0] = 2; //初始化原地待一天 + 访问下一个房间一天
        for (int i = 1; i < len; i++) {
            int to = nextVisit[i];
            dp[i] = 2 + dp[i - 1];
            if (to != 0) {
                dp[i] = (dp[i] - dp[to - 1] + mod) % mod; //避免负数
            }

            dp[i] = (dp[i] + dp[i - 1]) % mod;
        }
        return dp[len - 2]; //题目保证n >= 2
    }
    
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
    }
}