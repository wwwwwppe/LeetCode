namespace Demo2529;

class Program
{
    public int MaximumCount(int[] nums)
    {
        int pos = 0, neg = 0;
        foreach (var num in nums)
        {
            if (num > 0) pos++;
            else if (num < 0) neg++;
        }

        return Math.Max(pos, neg);
    }
    
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
    }
}