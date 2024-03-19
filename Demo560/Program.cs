namespace Demo560;

class Program
{
    public int SubarraySum(int[] nums, int k)
    {
        int count = 0, pre = 0;
        var mp = new Dictionary<int, int> { { 0, 1 } };
        foreach (var t in nums)
        {
            pre += t;
            if (mp.TryGetValue(pre - k, out var a))
                count += a;

            if (!mp.TryAdd(pre, 1))
                mp[pre]++;
        }

        return count;
    }

    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
    }
}