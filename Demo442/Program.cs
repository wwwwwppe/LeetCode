namespace Demo442;

class Program
{
    public IList<int> FindDuplicates(int[] nums)
    {
        List<int> lists = [];
        HashSet<int> a = [];
        lists.AddRange(nums.Where(num => !a.Add(num)));
        return lists;
    }

    public IList<int> FindDuplicates1(int[] nums)
    {
        List<int> lists = [];
        int n = nums.Length;
        for (var i = 0; i < nums.Length; i++)
        {
            nums[(nums[i]-1)%n] += n;
        }
        for (var i = 0; i < nums.Length; i++)
        {
            if (nums[i] > 2 * n)
            {
                lists.Add(i+1);
            }
        }

        return lists;
    }
    
    public IList<int> FindDuplicates2(int[] nums)
    {
        int n = nums.Length;

        for (var i = 0; i < nums.Length; i++)
        {
            nums[(nums[i]-1)%n] += n;
        }

        var duplicates = nums
            .Select((x, i) => new {Index = i+1, Sum = x}) 
            .Where(x => x.Sum > 2*n)
            .Select(x => x.Index);

        return duplicates.ToList();;
    }

    public IList<int> FindDuplicates3(int[] nums)
    {
        var groups = nums.GroupBy(n => n);

        var duplicates = groups
            .Where(g => g.Count() > 1)
            .Select(g => g.Key);

        return duplicates.ToList(); 
    }
    
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
    }
}