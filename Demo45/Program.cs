namespace Demo45;

class Program
{
    public int Jump(int[] nums)
    {
        int num = 0;
        int n = nums.Length - 1;
        while (n>0)
        {
            int t = n;
            for (int i = n-1; i >= 0; i--)
            {
                if (nums[i] + i >= n)
                {
                    t = i;
                }
            }

            n = t;
            num++;
        }

        return num;
    }
    
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
    }
}