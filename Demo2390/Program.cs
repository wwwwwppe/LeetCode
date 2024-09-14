namespace Demo2390;

class Program
{
    public string RemoveStars(string s)
    {
        var len = 0;
        List<char> list = [];
        for (int i = s.Length - 1; i >= 0; i--)
        {
            if (s[i] == '*')
            {
                len++;
            }
            else if (len == 0)
            {
                list.Add(s[i]);
            }
            else
            {
                len--;
            }
        }
        list.Reverse();
        return new string(list.ToArray());
    }

    static void Main(string[] args)
    {
        String s = "leet**cod*e";
        Program program = new Program();
        System.Console.WriteLine(program.RemoveStars(s));
    }
}
