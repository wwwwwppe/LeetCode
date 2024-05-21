namespace Demo209;

class Program
{
    public int MinSubArrayLen(int target, int[] nums)
    {
        int minRet = Int32.MaxValue;
        int left = 0, right = 0;
        long sum = nums[right];
        while (left<nums.Length && left <= right)
        {
            while (left<nums.Length&& left <= right &&sum >= target)
            {
                if (left == right) return 1;
                minRet = Math.Min(minRet, right - left + 1);
                sum -= nums[left];
                left++;
            }

            if (right == nums.Length-1) break;
            while (right< nums.Length-1 &&sum < target)
            {
                sum += nums[++right];
            }
        }

        return minRet == Int32.MaxValue ? 0 : minRet;

    }
    
    static void Main(string[] args)
    {
        Program program = new Program();
        program.MinSubArrayLen(7, [2, 3, 1, 2, 4, 3]);
        Console.WriteLine("Hello, World!");
    }
}