namespace Demo312;

class Program
{
    public int[][] rec;
    public int[] val;
    
    public int MaxCoins(int[] nums)
    {
        int n = nums.Length;
        val = new int[n + 2];
        for (int i = 1; i <= n; i++)
        {
            val[i] = nums[i - 1];
        }

        val[0] = val[n + 1] = 1;
        rec = new int[n + 2][];
    }

    public int solve(int left, int right)
    {
        if (left >= right - 1)
        {
            return 0;
        }
        if()
    }
    
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
    }
}