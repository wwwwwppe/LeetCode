namespace Demo2744;

class Program
{
    public int MaximumNumberOfStringPairs(string[] words)
    {
        var ret = 0;
        HashSet<string> hashSet = [];
        foreach (var word in words)
        {
            if(!hashSet.Contains(word)&&hashSet.Contains(word[1].ToString() +word[0]))
            {
                ret++;
            }
            hashSet.Add(word);
        }

        return ret;
    }
    
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
    }
}