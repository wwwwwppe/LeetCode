namespace Demo2981;

class Program
{
    public int MaximumLength(string s)
    {
        if (s.ToCharArray().GroupBy(x => x).Max(m => m.Sum(c => c)) < 3) return -1;
        int sum = 0;
        var cs = s.ToCharArray();
        for (var i = 0; i < cs.Length; i++)
        {
            
        }

        return 0;
    }
    
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
    }
}