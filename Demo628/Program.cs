namespace Demo628;

class Program
{
    public int MaximumProduct(int[] nums)
    {
        Array.Sort(nums, (a, b) => b - a);
        return Math.Max(nums[0] * nums[1] * nums[2], nums[^1] * nums[^2] * nums[0]);
    }
    
    static void Main(string[] args)
    {
        int[] nums = [1, 2, 3];
        Program program = new Program();
        Console.WriteLine(program.MaximumProduct(nums));
    }
}