namespace Demo383;

class Program
{
    public bool CanConstruct(string ransomNote, string magazine)
    {
        Dictionary<char, int> dictionary = [];
        foreach (var c in ransomNote.Where(c => !dictionary.TryAdd(c, 1)))
        {
            dictionary[c]++;
        }
        
        foreach (var c in magazine)
        {
            if (!dictionary.TryGetValue(c, out int value)) continue;
            dictionary[c]--;
            if (dictionary[c] == 0) dictionary.Remove(c);
        }

        return dictionary.Count == 0;
    }
    
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
    }
}