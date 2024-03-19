using System.Text;

namespace Demo2864;

class Program
{
    public string MaximumOddBinaryNumber(string s)
    {
        if (s.Length == 1) return s;
        var chars = s.ToCharArray();
        Array.Sort(chars,(a,b)=> b-a);
        for (var i = chars.Length - 1; i >= 0; i--)
        {
            if (chars[i] == '1')
            {
                chars[i] = '0';
                break;
            }
        }

        chars[^1] = '1';
        StringBuilder sb = new StringBuilder();
        foreach (var c in chars)
        {
            sb.Append(c);
        }
        return sb.ToString();
    }
    
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
    }
}