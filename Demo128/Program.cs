namespace Demo128;

class Program
{
    public int LongestConsecutive(int[] nums)
    {
        int ret = 0;
        HashSet<int> hashSet = new HashSet<int>();
        foreach (var num in nums)
        {
            hashSet.Add(num);
        }
        
        
        foreach (var i in hashSet)
        {
            if (!hashSet.Contains(i - 1))
            {
                int a = i;
                int b = 1;

                while (hashSet.Contains(a+1))
                {
                    a++;
                    b++;
                }

                ret = Math.Max(ret, b);
            } 
        }

        return ret;
    }
    
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
    }
}