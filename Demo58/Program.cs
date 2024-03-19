namespace Demo58;

class Program
{
    //一分钟
    public int LengthOfLastWord(string s)
    {
        var strs = s.Trim().Split(" ");
        return strs[^1].Length;
    }
    
    //用Linq的方法

    public int LengthOfLastWordTwo(string s)
    {
        return s.Split(' ').Last(x => x != "").Length; 
    }
    
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
    }
}