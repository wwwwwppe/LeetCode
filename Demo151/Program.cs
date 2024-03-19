using System.Text;

namespace Demo151;

class Program
{
    public string ReverseWords(string s)
    {
        s = s.Trim();
        StringBuilder sb = new StringBuilder();
        var strs = s.Split(" ");
        for (var i = strs.Length - 1; i >= 0; i--)
        {
            if(strs[i]!="" &&strs[i]!=" ")
                sb.Append(strs[i]+" ");
        }

        return sb.ToString().Trim();
    }
    
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
    }
}