namespace Demo2735;

class Program
{
    public long MinCost(int[] nums, int x)
    {
        var sum = nums.Sum(i => (long)i);
        var length = nums.Length;
        var newNums = new long[length];
        nums.CopyTo(newNums,0);
        //这个是转动次数
        for (long i = 0; i < length; i++)
        {
            // 计算当前的成本
            for (long j = 0; j < length; j++)
                newNums[j] = Math.Min(newNums[j], nums[(j + i) % length]);
            sum = Math.Min(newNums.Sum() + i * x, sum);
        }
        return sum;
    }

    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
    }
}