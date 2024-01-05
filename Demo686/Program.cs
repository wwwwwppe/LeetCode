namespace Demo686;

class Program
{
    public static int RepeatedStringMatch(string a, string b) {
        //先判断是否存在
        if (!a.GroupBy(c => c)
                .Select(g => new { Char = g.Key, Count = g.Count() })
                .Except(b.GroupBy(c => c)
                    .Select(g => new { Char = g.Key, Count = g.Count() }))
                .Any())
        {
            return -1;
        }

        int i = 0;
        string d = "";
        while (d.Length<b.Length * 2 || i<2)
        {
            i++;
            d += a;
            if (d.Contains(b)) return i;
        }

        return -1;
    }
    
    static void Main(string[] args)
    {
        string a = "abcd";
        string b = "cdabcdab";
        Console.WriteLine(RepeatedStringMatch(a,b));
    }
}