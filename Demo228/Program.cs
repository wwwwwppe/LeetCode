using System.Collections;

namespace Demo228;

class Program
{
    public IList<string> SummaryRanges(int[] nums)
    {
        if (nums.Length == 0)
        {
            return [];
        }
        IList<string> strs = [];
        int left = 0, right = 0;
        for (var i = 1; i < nums.Length; i++)
        {
            if (nums[i] == nums[i - 1] + 1)
            {
                right++;
            }
            else
            {
                strs.Add(left == right ? $"{nums[left]}" : $"{nums[left]}->{nums[right]}");
                left = i;
                right = i;
            }
        }
        strs.Add(left == right ? $"{nums[left]}" : $"{nums[left]}->{nums[right]}");
        return strs;
    }
    
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
    }
}