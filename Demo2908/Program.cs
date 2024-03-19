namespace Demo2908;

class Program
{
    public int MinimumSum(int[] nums)
    {
        int min = -1;

        for (var i = 0; i < nums.Length - 2; i++)
        {
            for (var i1 = i + 1; i1 < nums.Length - 1; i1++)
            {
                for (var i2 = i1 + 1; i2 < nums.Length; i2++)
                {
                    if (nums[i1] > nums[i] && nums[i1] > nums[i2])
                    {
                        if (min == -1) min = nums[i] + nums[i1] + nums[i2];
                        min = Math.Min(min, nums[i] + nums[i1] + nums[i2]);
                    }
                }
            }
        }

        return min;
    }

    public int MinimumSum2(int[] nums)
    {
        int left = nums[0], right = nums[^1];
        int min = -1;
        int[] demo = new int[nums.Length];
        for (var i = 0; i < nums.Length; i++)
        {
            if (nums[i] <= left)
            {
                left = nums[i];
            }
            else
            {
                demo[i] = left + nums[i];
            }
        }

        for (var i = demo.Length - 2; i >= 0; i--)
        {
            right = Math.Min(right, nums[i]);
            if (demo[i] == 0)
                continue;
            if (right > nums[i])
            {
                if (min == -1)
                {
                    min = right + demo[i];
                }

                min = Math.Min(min, right + demo[i]);
            }
        }

        return min;
    }

    static void Main(string[] args)
    {
        int[] nums = [5, 4, 8, 7, 10, 2];
        Program program = new Program();
        int a = program.MinimumSum(nums);
        Console.WriteLine("Hello, World!");
    }
}