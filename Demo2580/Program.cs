﻿namespace Demo2580;

class Program
{
    public int CountWays(int[][] ranges)
    {
        int MOD = 1000000007;
        
        Array.Sort(ranges,(a,b) => a[0]-b[0]);

        int res = 1;
        for (int i = 0; i < ranges.Length;)
        {
            int r = ranges[i][1];
            int j = i + 1;
            while (j<ranges.Length&&ranges[j][0]<=r)
            {
                r = Math.Max(r, ranges[j][1]);
                j++;
            }

            res = res * 2 % MOD;

            i = j;
        }

        return res;
    }
    
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
    }
}