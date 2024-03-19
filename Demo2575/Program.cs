namespace Demo2575;

class Program
{
    public static int[] DivisibilityArray(string word, int m)
    {
        long w = 0;
        int n = word.Length;
        var ret = new int[word.Length];
        for(int i = 0;i<n;i++)
        {
            w = w * 10 + long.Parse(word[i].ToString());
            if (w % m == 0) ret[i] = 1;
        }

        return ret;
    }
    
    static void Main(string[] args)
    {
        string word = "1010";
        int m = 10;
        int[] a = DivisibilityArray(word, m);
        
        
        foreach (var i in a)
        {
            Console.WriteLine(a[i]);
        }
    }
}