namespace Demo448;

class Program
{
    public IList<int> FindDisappearedNumbers(int[] nums)
    {
        List<int> lists = Enumerable.Range(1, nums.Length).ToList();
        var a = nums.ToHashSet();
        lists.RemoveAll(list => a.Contains(list));
        return lists.ToArray();
    }
    
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
    }
}