namespace Demo438;

class Program
{
    public IList<int> FindAnagrams(string s, string p)
    {
        if (p.Length > s.Length) return [];
        int length = p.Length;
        int[] sames = new int[26];
        foreach (var c in p)
        {
            sames[c - 'a']++;
        }
        int left = 0, right = length - 1;
        IList<int> list = new List<int>();
        int[] nums = new int[26];
        for (int i = 0; i < length; i++)
        {
            nums[s[i] - 'a']++;
        }
        if(IsSame(sames,nums)) list.Add(0);
        while (right<s.Length)
        {
            right++;
            nums[s[right] - 'a']++;
            nums[s[left] - 'a']--;
            left++;
            if(IsSame(sames,nums)) list.Add(left);
        }

        return list;

        bool IsSame(int[] a, int[] b)
        {
            if (a.Length != b.Length) return false;
            for (var i = 0; i < a.Length; i++)
            {
                if (a[i] != b[i]) return false;
            }

            return true;
        }
    }
    
    static void Main(string[] args)
    {
        Program program = new Program();
        string s = "cbaebabacd";
        string p = "abc";
        program.FindAnagrams(s, p);
        Console.WriteLine("Hello, World!");
    }
}