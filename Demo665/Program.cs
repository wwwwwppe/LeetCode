namespace Demo665;

class Program
{
    public bool CheckPossibility(int[] nums)
    {
        if (nums.Length == 1) return true;
        bool a = false;
        if (nums[0] > nums[1])
        {
            a = true;
            nums[0] = nums[1];
        }
        
        for (var i = 2; i < nums.Length; i++)
        {
            if (!a)
            {
                if (nums[i] < nums[i - 1])
                {
                    if (nums[i] < nums[i - 2])
                    {
                        nums[i] = nums[i - 1];
                    }
                    else
                    {
                        nums[i - 1] = nums[i - 2];
                    }

                    a = true;
                }
            }
            else
            {
                if (nums[i] < nums[i - 1])
                    return false;
            }
        }
        return true;
    }

    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
    }
}