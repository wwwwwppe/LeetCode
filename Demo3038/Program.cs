namespace Demo3038;

class Program
{
    public int MaxOperations(int[] nums)
    {
        int sum = 1;
        int ret = nums[0] + nums[1];
        for (var i = 2; i < nums.Length-1; i+=2 )
        {
            if (ret == nums[i] + nums[i + 1]) sum++;
            else
            {
                break;
            }
        }

        return sum;
    }
    
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
    }
}