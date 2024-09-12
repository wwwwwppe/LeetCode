namespace Demo503;

class Program
{
    public int[] NextGreaterElements(int[] nums)
    {
        var length = nums.Length;
        int[] rets = new int[nums.Length];
        for (var i = 0; i < nums.Length; i++)
        {
            int max = -1;
            for (var i1 = 0; i1 < nums.Length; i1++)
            {
                if (nums[(i + i1) % length] > nums[i])
                {
                    max = nums[(i + i1) % length];
                    break;
                }
            }

            rets[i] = max;
        }

        return rets;
    }
    
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
    }
}