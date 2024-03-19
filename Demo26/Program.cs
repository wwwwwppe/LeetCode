namespace Demo26;

class Program
{
    public int RemoveDuplicates(int[] nums)
    {
        HashSet<int> hashSet = new HashSet<int>();
        foreach (var num in nums)
        {
            hashSet.Add(num);
        }

        int[] table = [.. hashSet];
        Array.Sort(table);
        
        for (var i = 0; i < table.Length; i++)
        {
            nums[i] = table[i];
        }

        return table.Length;
    }
    
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
    }
}