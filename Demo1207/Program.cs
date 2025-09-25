namespace Demo1207;

class Program
{
    public bool UniqueOccurrences(int[] arr)
    {
        Dictionary<int, int> dict = new Dictionary<int, int>();
        foreach (var i in arr)
        {
            if (!dict.TryAdd(i, 0))
            {
                dict[i]++;
            }
        }
        var set = new HashSet<int>();
        return dict.All(keyValuePair => set.Add(keyValuePair.Value));
    }

    public bool UniqueOccurrencesLinq(int[] arr)
    {
        var counts = arr.GroupBy(x => x)
            .Select(g => g.Count())
            .ToArray();

        return counts.Length == counts.Distinct().Count();
    }
    
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
    }
}