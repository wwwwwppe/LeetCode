namespace Week392;

public class Gram3
{
    public long MinOperationsToMakeMedianK(int[] nums, int k)
    {
        long chao = 0;
        int chang = nums.Length / 2;
        Array.Sort(nums);
        int mid = nums.Length / 2;
        if (nums[mid] == k)
            return chao;
        if (k > nums[mid])
        {
            for (int i = mid; i < nums.Length; i++)
            {
                if (k > nums[i])
                {
                    chao += k - nums[i];
                }
                else
                {
                    break;
                }
            }
        }

        if (k < nums[mid])
        {
            for (int i = mid; i >= 0; i--)
            {
                if (k < nums[i])
                {
                    chao += nums[i] - k;
                }
                else
                {
                    break;
                }
            }
        }

        return chao;
    }
}