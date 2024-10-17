namespace Demo3162;

class Program
{
    public int NumberOfPair(int[] nums1, int[] nums2, int k)
    {
        int ret = 0;
        for (int i = 0; i < nums1.Length; i++)
        {
            for (int j = 0; j < nums2.Length; j++)
            {
                int demo = nums2[j] * k;
                if (demo == 0)
                    continue;
                if (nums1[i] % demo == 0)
                    ret++;
            }
        }
        return ret;
    }

    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
    }
}
