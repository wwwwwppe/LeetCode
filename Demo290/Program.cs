namespace Demo290;

class Program
{
    public bool WordPattern(string pattern, string s)
    {
        string[] strs = s.Split(" ");
        if (pattern.Length != strs.Length)
        {
            return false;
        }
        Dictionary<char, string> dictionary = [];
        Dictionary<string, char> dictionary2 = [];
        for (var i = 0; i < pattern.Length; i++)
        {
            if (!dictionary.TryGetValue(pattern[i],out string str))
            {
                if (dictionary2.ContainsKey(strs[i]))
                {
                    return false;
                }
                dictionary.Add(pattern[i],strs[i]);
                dictionary2.Add(strs[i],pattern[i]);
            }
            else
            {
                if (str != strs[i])
                {
                    return false;
                }
            }
        }

        return true;
    }
    
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
    }
}