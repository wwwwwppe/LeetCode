namespace Demo2673;

class Program
{
    public int MinIncrements(int n, int[] cost)
    {
        int ans = 0;
        for (var i = n - 2; i > 0; i = i - 2)
        {
            ans += Math.Abs(cost[i] - cost[i + 1]);
            cost[i / 2] += Math.Max(cost[i], cost[i + 1]);
        }

        return ans;
    }
    
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
    }
}