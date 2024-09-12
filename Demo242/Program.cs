namespace Demo242;

class Program
{
    public bool IsAnagram(string s, string t)
    {
        if (s.Length != t.Length)
        {
            return false;
        }
        Dictionary<char, int> dictionary = [];
        foreach (var c in s.Where(c => !dictionary.TryAdd(c,1)))
        {
            dictionary[c]++;
        }
        
        foreach (var c in t)
        {
            if (!dictionary.TryGetValue(c, out int value))
            {
                return false;
            }

            dictionary[c] = --value;
            if (value == 0)
            {
                dictionary.Remove(c);
            }
        }

        return dictionary.Count == 0;

    }
    
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
    }
}