namespace Demo1004;

class Program
{
    public static int LongestOnes(int[] nums, int k)
    {
        int left = 0, right = 0;
        int max = 0,limitNum = k;
        while (right < nums.Length)
        {
            if (nums[right] == 1)
            {
                right++;
            }
            else if (limitNum > 0)
            {
                limitNum--;
                right++;
            }
            else
            {
                max = Math.Max(max, right - left);
                while (left < right && limitNum == 0)
                {
                    if (nums[left] == 0 && k!=0)
                    {
                        limitNum++;
                    }
                    left++;
                }
                right++;
            }
        }
        return Math.Max(max, right - left);
    }
    
    static void Main(string[] args)
    {
        int[] nums = [0, 0, 1, 1, 0, 0, 1, 1, 1, 0, 1, 1, 0, 0, 0, 1, 1, 1, 1];
        int k = 3;
        LongestOnes(nums, k);
        
        Console.WriteLine("Hello, World!");
    }
}