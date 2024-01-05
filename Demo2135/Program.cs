namespace Demo2135;

class Program
{
    public int WordCount(string[] startWords, string[] targetWords) {
        //先二进制先转化一下

        int GetOx(string a)
        {
            int result = 0;
            for (var i = 0; i < a.Length; i++)
            {
                char c = a[i];
                int pos = c - 'a'; 
                result |= 1 << pos; 
            }
            return result;
        }

        return 0;
    }
    
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
    }
}