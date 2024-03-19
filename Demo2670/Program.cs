namespace Demo2670;

class Program
{
    public int[] DistinctDifferenceArray(int[] nums)
    {
        var arr = new int[nums.Length];
        var leftSet = new HashSet<int>();
        var rightSet = new Dictionary<int,int>();
        foreach (var t in nums)
        {
            if(!rightSet.TryAdd(t,1)) rightSet[t]++;
        }
        
        for (var i = 0; i < nums.Length; i++)
        {
            leftSet.Add(nums[i]);
            rightSet[nums[i]]--;
            if(rightSet[nums[i]]==0) rightSet.Remove(nums[i]);
            arr[i] = leftSet.Count - rightSet.Count;
        }

        return arr;

    }
    
    static void Main(string[] args)
    {
        int[] nums = [3,2,3,4,2];
        Program program = new Program();
        program.DistinctDifferenceArray(nums);
        Console.WriteLine("Hello, World!");
    }
}