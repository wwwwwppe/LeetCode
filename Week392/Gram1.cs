namespace Week392;

public class Gram1
{
    public int LongestMonotonicSubarray(int[] nums)
    {
        if (nums.Length == 1) return 1;
        int cha = 1, right = 1;
        int num = 1;
        int max = 0;
        while (right< nums.Length)
        {
            int a = (nums[right] - nums[right-1])*cha;
            if (a>0)
            {
                num++;
            }else if (nums[right] - nums[right-1] == 0)
            {
                max = Math.Max(max, num);
                cha = nums[right] - nums[right - 1];
                num = 1;
            }
            else
            {
                max = Math.Max(max, num);
                cha = nums[right] - nums[right - 1]; 
                num = 2;
            }

            right++;
        }

        return Math.Max(max, num);
    } 
}