namespace Demo30;

class Program
{
    public IList<int> FindSubstring(string s, string[] words)
    {
        IList<int> lists = [];
        // words = words.OrderByDescending(x => x.Length).ToArray();
        var dicNum = new int[26];
        foreach (var word in words)
        {
            foreach (var c in word)
            {
                dicNum[c - 'a']--;
            }
        }

        int charLength = words.Sum(x => x.Length);
        if (s.Length < charLength) return [];
        for (int i = 0; i < charLength; ++i)
        {
            dicNum[s[i] - 'a']++;
        }

        for (var i = 0; i < s.Length-charLength; i++)
        {
            if (returnDicNum())
            {
                int[] temp = new int[words.Length];
                bool b = false;
                for (int j = i; j < i + charLength; j+= words[0].Length)
                {
                    string a = "";
                    for (var i1 = 0; i1 < words[0].Length; i1++)
                    {
                        a += s[j + i1];
                    }
                    for (var i1 = 0; i1 < words.Length; i1++)
                    {
                        if (words[i1] == a && temp[i1] == 0)
                        {
                            temp[i1]++;
                        }
                        else
                        {
                            b = true;
                            break;
                        }
                    }
                    if(b) break;
                }
                if(!b) lists.Add(i);
            }

            if (i != s.Length - charLength - 1)
            {
                dicNum[s[i] - 'a']--;
                dicNum[s[i + charLength] - 'a']++;
            }
        }

        return lists;
            
        bool returnDicNum()
        {
            return dicNum.All(i => i == 0);
        }

    }
    
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
    }
}