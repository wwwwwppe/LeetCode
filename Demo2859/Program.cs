namespace Demo2859;

class Program
{
    public int SumIndicesWithKSetBits(IList<int> nums, int k)
    {
        int sum = 0;
        for (var i = 0; i < nums.Count; i++)
        {
            if (int.PopCount(i) == k)
            {
                sum += nums[i];
            }
        }

        return sum;
    }
    
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
    }
}