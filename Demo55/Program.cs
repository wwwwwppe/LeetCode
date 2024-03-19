namespace Demo55;

class Program
{
    public bool CanJump(int[] nums)
    {
        int k = 0;
        for (var i = 0; i < nums.Length; i++)
        {
            if (i > k) return false;
            k = Math.Max(k, i + nums[i]);
        }

        return true;
    }
    
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
    }
}