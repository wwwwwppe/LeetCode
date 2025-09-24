namespace Demo521;

class Program
{
    public int FindLUSlength(string a, string b)
    {
        return a == b ? -1 : Math.Max(a.Length, b.Length);
    }
    
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
    }
}