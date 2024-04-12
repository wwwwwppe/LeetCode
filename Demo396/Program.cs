namespace Demo396;

class Program
{
    public int MaxRotateFunction(int[] nums)
    {
        //直接模拟还是不行的，时间上是会超的，那么还是要找规律。
        //整个数据是向右移动，说明除了最后一个的被挤成0了，其他的都是增加了一倍，那么我可以将总和和第一次的和给求出来
        // 然后随着每一次运动，都是增加一倍，然后再减去n * 最后一个的数据，就是当前数据的大小

        int sum = nums.Sum();
        int sum1 = nums.Select((t, i) => i * t).Sum();
        int max = sum1;
        int n = nums.Length;
        for (var i = 1; i < n; i++)
        {
            sum1 = sum1 + sum - n * nums[n - i];
            if (max < sum1) max = sum1;
        }

        return max;
    }
    
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
    }
}