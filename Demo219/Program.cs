namespace Demo219;

class Program
{
    public bool ContainsNearbyDuplicate(int[] nums, int k)
    {
        if (k == 0)
        {
            return false;
        }
        HashSet<int> hashSet = [];
        if (k >= nums.Length)
        {
            k = nums.Length - 1;
        }
        for (int i = 0; i <= k; i++)
        {
            if (!hashSet.Add(nums[i]))
            {
                return true;
            }
        }

        for (int i = 1; i < nums.Length - k; i++)
        {
            hashSet.Remove(nums[i-1]);
            if (!hashSet.Add(nums[i + k]))
            {
                return true;
            }
        }

        return false;
    }
    
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
    }
}