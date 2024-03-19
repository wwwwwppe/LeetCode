namespace Demo2129;

class Program
{
    public static string CapitalizeTitle(string title)
    {
        var titles = title.Split(' ');
        string a = "";
        foreach (var s in titles)
        {
            if (s.Length <= 2)
            {
                a += s.ToLower();
            }
            else
            {
                string b = s.ToLower();
                char c = (char)(b[0] + 'A' - 'a');
                a += (c.ToString() + b.Substring(1,b.Length-1));
            }

            a += " ";
        }

        return a.Trim();
    }
    
    static void Main(string[] args)
    {
        string title = "capiTalIze tHe titLe";
        Console.WriteLine(CapitalizeTitle(title));
    }
}