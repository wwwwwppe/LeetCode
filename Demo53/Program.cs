using System.Diagnostics;

namespace Demo53;

class Program
{
    public static int MaxSubArray(int[] nums)
    {
        int pre=0, ret = nums[0];
        foreach (var num in nums)
        {
            pre = Math.Max(pre + num, num);
            ret = Math.Max(pre, ret);
        }

        return ret;
    }
    
    public static int MaxSubArrayTwo(int[] nums)
    {
        int pre=0, ret = nums[0];
        for (int i = 0; i < nums.Length; i++)
        {
            pre = Math.Max(pre + nums[i], nums[i]);
            ret = Math.Max(pre, ret);
        }

        return ret;
    }
    
    static void Main(string[] args)
    {
        List<int> list = [];
        Random random = new Random();
        for (int i = 0; i < 100000; i++)
        {
            int randomNum = random.Next(-1000000, 1000001);
            list.Add(randomNum);
        }
        int[] arr = list.ToArray();
        
        DateTime time1 = DateTime.Now;
        var a = MaxSubArray(arr);
        DateTime time2 = DateTime.Now;
        TimeSpan timeSpan1 = time2 - time1;
        
        
        DateTime time1E = DateTime.Now;
        var b = MaxSubArrayTwo(arr);
        DateTime time2E = DateTime.Now;
        TimeSpan timeSpan2 = time2E - time1E;
        
        Stopwatch stopwatch1 = Stopwatch.StartNew();
        MaxSubArray(arr);
        stopwatch1.Stop();
        var c = stopwatch1.Elapsed;

        Stopwatch stopwatch2 = Stopwatch.StartNew();
        MaxSubArrayTwo(arr);
        stopwatch2.Stop();
        var d = stopwatch2.Elapsed;
        
        Console.WriteLine(timeSpan1+"\n"+timeSpan2+"\n"+c+"\n"+d);
    }
}