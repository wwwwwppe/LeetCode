namespace Demo28;

class Program
{
    public int StrStr(string haystack, string needle)
    {
        return haystack.Contains(needle) ? haystack.Split(needle)[0].Length : -1;
    }
    
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
    }
}