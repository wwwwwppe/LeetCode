namespace Demo2956;

class Program
{
    public int[] FindIntersectionValues(int[] nums1, int[] nums2)
    {
        var hashSet1 = new HashSet<int>();
        var hashSet2 = new HashSet<int>();
        foreach (var i in nums1)
        {
            hashSet1.Add(i);
        }
        
        foreach (var i in nums2)
        {
            hashSet2.Add(i);
        }

        int sum1 = 0, sum2 = 0;

        //有点多此一举了，直接用contains来数组里面判断就OK了。
        sum1 += nums1.Count(i => hashSet2.Contains(i));
        sum2 += nums2.Count(i => hashSet1.Contains(i));

        return [sum1, sum2];
    }
    
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
    }
}