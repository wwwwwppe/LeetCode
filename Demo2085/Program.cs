namespace Demo2085;

class Program
{
    public int CountWords(string[] words1, string[] words2)
    {
        int ret = 0;
        Dictionary<string, int> dictionary = new Dictionary<string, int>();
        foreach (var s in words1)
        {
            if (!dictionary.TryAdd(s, 0))
            {
                dictionary[s]++;
            }
        }

        Dictionary<string, int> dictionary2 = new Dictionary<string, int>();
        foreach (var s in words2)
        {
            if (!dictionary2.TryAdd(s, 0))
            {
                dictionary2[s]++;
            }
        }
        
        foreach (var (key, value) in dictionary)
        {
            int i;
            if (value == 0 && dictionary2.TryGetValue(key, out i))
            {
                if (i == 0) ret++;
            }
        }

        return ret;
    }
    
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
    }
}