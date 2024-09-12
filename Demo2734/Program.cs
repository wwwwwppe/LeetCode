namespace Demo2734;

class Program
{
    public string SmallestString(string s)
    {
        var chars = s.ToCharArray();
        var isFirst = false;
        for (var i = 0; i < chars.Length; i++)
        {
            if (chars[i] != 'a')
            {
                isFirst = true;
                chars[i] = (char)(chars[i] - 1);
            }else if (isFirst)
            {
                break;
            }
        }

        if (!isFirst)
        {
            chars[^1] = 'z';
        }

        return new string(chars) ?? "";
    }
    
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
    }
}