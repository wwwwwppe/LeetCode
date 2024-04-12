namespace Demo485;

class Program
{
    public int FindMaxConsecutiveOnes(int[] nums)
    {
        int retMax = 0;
        int max=0;
        for (var i = 0; i < nums.Length; i++)
        {
            if (nums[i] == 1) max++;
            else
            {
                if (retMax < max) retMax = max;
                max = 0;
            }
        }

        return retMax > max ?retMax: max;
    }
    
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
    }
}