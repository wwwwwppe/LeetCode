namespace Demo392;

class Program
{
    public bool IsSubsequence(string s, string t)
    {
        int right = 0;
        foreach (var t1 in s)
        {
            bool a = false;
            for (; right < t.Length; right++)
            {
                if (t1 == t[right])
                {
                    a = true;
                    //没考虑到break完后，right不会++
                    right++;
                    break;
                }
            }

            if (!a) return false;
        }

        return true;
    }
    
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
    }
}