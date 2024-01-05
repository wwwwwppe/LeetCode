namespace Demo001;

class Program
{
    public int[] TwoSum(int[] nums, int target)
    {
        var dictionary = new Dictionary<int, int>();
        for (var i = 0; i < nums.Length; i++)
        {
            if (dictionary.TryGetValue(target - nums[i], out var value2))
            {
                return [i, value2];
            }
            dictionary.Add(nums[i],i); 
        }
        foreach (var (key, value) in dictionary)
        {
            if (dictionary.TryGetValue(target - key, out var value2))
            {
                return [value, value2];
            }
        }
        
        return []; 
    }
    
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
    }
}