namespace Demo303;

public class NumArray
{
    private int[] pre;
    
    public NumArray(int[] nums)
    {
        pre = new int[nums.Length + 1];

        for (var i = 1; i <= nums.Length; i++)
        {
            pre[i] = pre[i - 1] + nums[i - 1];
        }
    }
    
    public int SumRange(int left, int right) {
        return pre[right + 1] - pre[left];
    }
}