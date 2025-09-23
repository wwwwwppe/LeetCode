namespace Demo1493;

class Program
{
    public static int LongestSubarray(int[] nums) {
            // if(!nums.Contains(1)) return 0;
            // if(!nums.Contains(0)) return nums.Length-1;
            // int left = 0, right = 0, de = 1,max = 0;
            // while (right < nums.Length)
            // {
            //     if (nums[right] == 0 && de > 0)
            //     {
            //         de--;
            //     }
            //     else if (nums[right] == 0 && de == 0)
            //     {
            //         while (left < right && de == 0)
            //         {
            //             if(nums[left] == 0) de++;
            //             left++;
            //         }
            //     }
            //     max = Math.Max(max, right - left);
            //     right++;
            // }
            //
            // return Math.Max(max,right - left);
            int left = 0, zeros = 0, best = 0;
            for (int right = 0; right < nums.Length; right++)
            {
                if (nums[right] == 0) zeros++;

                while (zeros > 1)
                {
                    if (nums[left] == 0) zeros--;
                    left++;
                }

                // 当前窗口长度（包含right）：right - left + 1
                best = Math.Max(best, right - left + 1);
            }

            // 必须删除一个元素
            return best - 1;
    }
    
    static void Main(string[] args)
    {
        int[] nums = [0, 1, 1, 1, 0, 1, 1, 0, 1];
        LongestSubarray(nums);
    }
}