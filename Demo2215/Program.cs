namespace Demo2215;

class Program
{
    public static IList<IList<int>> FindDifference(int[] nums1, int[] nums2)
    {
        HashSet<int> set1 = nums1.ToHashSet();
        HashSet<int> set2 = nums2.ToHashSet();
        var result = new List<IList<int>>();
        var result0 = set1.Intersect(set2).ToList();
        result0.ForEach(t =>
        {
            set1.Remove(t);
            set2.Remove(t);
        });
        result.Add(set1.ToList());
        result.Add(set2.ToList());
        return result;
    }

    public static IList<IList<int>> FindDifferenceLinq(int[] nums1, int[] nums2)
    {
        var only1 = nums1.Except(nums2).ToList();
        var only2 = nums2.Except(nums1).ToList();
        return new List<IList<int>>{only1, only2};
    }
    

    static void Main(string[] args)
    {
        int[] nums1 =
            [1, 2, 3];
        int[] nums2 =
            [2, 4, 6];
        FindDifference(nums1, nums2);
    }
}