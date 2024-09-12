namespace Demo76;

class Program
{
    public string MinWindow(string s, string t)
    {
        Dictionary<char, int> dic = [];
        foreach (var c in t.Where(c => !dic.TryAdd(c, 1)))
        {
            dic[c]++;
        }
        Dictionary<char, int> dictionary = new Dictionary<char, int>(dic);
        
        foreach (var c in s.Where(c => dic.ContainsKey(c)).Where(c => --dic[c] == 0))
        {
            dic.Remove(c);
        }

        if (dic.Count != 0) return "";



        return "";


        bool checkDic()
        {
            foreach (var (key, value) in dic)
            {
                if (!dictionary.TryGetValue(key, out int v) || v != value)
                    return false;
            }
            return true;
        } 
    }
    
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
    }
}