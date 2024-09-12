namespace Demo205;

class Program
{
    // 这边要多考虑一下双向绑定的情况
    public bool IsIsomorphic(string s, string t)
    {
        Dictionary<char, char> dictionary = [];
        Dictionary<char, char> dictionary2 = [];
        for (var i = 0; i < s.Length; i++)
        {
            if (!dictionary.TryGetValue(s[i], out char targetChar))
            {
                if (dictionary2.ContainsKey(t[i]))
                {
                    return false;
                }
                dictionary.Add(s[i],t[i]);
                dictionary2.Add(t[i],s[i]);
            }
            else
            {
                if (targetChar != t[i])
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