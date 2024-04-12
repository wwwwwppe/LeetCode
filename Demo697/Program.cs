namespace Demo697;

class Program
{
    public int FindShortestSubArray(int[] nums)
    {
        int[] a = new int[50000];
        foreach (var num in nums)
        {
            a[num]++;
        }

        int max = a.Max();

        List<int> b = []; 
        for (var i = 0; i < a.Length; i++)
        {
            if(a[i] == max)
                b.Add(i);
        }

        int min = 50001;

        foreach (var i in b)
        {
            int left = 0, right = nums.Length - 1;
            while (true)
            {
                if (nums[left] != i) left++;
                else break;
            }
            while (true)
            {
                if (nums[right] != i) right--;
                else break;
            }

            min = Math.Min(min, right - left + 1);
        }

        return min;

    }


    public int FindShortestSubArray1(int[] nums)
    {
        var counts = nums.GroupBy(n => n)
            .ToDictionary(g => g.Key, g => g.Count());

        var maxCount = counts.Max(c => c.Value);

        var minRange = counts
            .Where(c => c.Value == maxCount)
            .Min(c => 
            {
                var left = Array.IndexOf(nums, c.Key); 
                var right = Array.LastIndexOf(nums,c.Key);
                return right - left + 1;
            });

        return minRange;
    }
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
    }
}