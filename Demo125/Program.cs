namespace Demo125;

class Program
{
    public bool IsPalindrome(string s)
    {
        List<char> a = [];
        foreach (var c in s)
        {
            if ((c - 'a' >= 0 && c - 'a' < 26) || (c - 'A' >= 0 && c - 'A' < 26) || (c - '0' >= 0 && c - '0' < 10))
            {
                if (c - 'A' >= 0 && c - 'A' < 26)
                {
                    a.Add((char)(c + 'a' -'A'));
                }else 
                    a.Add(c);
            }
        }
        int left = 0, right = a.Count - 1;
        while (left<right)
        {
            if (a[left] != a[right]) return false;
            left++;
            right--;
        }

        return true;
    }
    
    static void Main(string[] args)
    {
        Program program = new Program();
        string s = "A man, a plan, a canal: Panama";
        program.IsPalindrome(s);
        Console.WriteLine("Hello, World!");
    }
}