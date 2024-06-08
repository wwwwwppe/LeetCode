namespace Demo30;

class Program
{
    public IList<int> FindSubstringOri(string s, string[] words)
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

        for (var i = 0; i <= s.Length-charLength; i++)
        {
            if (returnDicNum())
            {
                int[] temp = new int[words.Length];
                bool b = false;
                for (int j = i; j < i + charLength; j+= words[0].Length)
                {
                    b = false;
                    // string a = "";
                    // for (var i1 = 0; i1 < words[0].Length; i1++)
                    // {
                    //     a += s[j + i1];
                    // }
                    string a = s.Substring(j, words[0].Length);
                    for (var i1 = 0; i1 < words.Length; i1++)
                    {
                        if (words[i1] == a && temp[i1] == 0)
                        {
                            temp[i1]++;
                            b = true;
                            break;
                        }

                    }
                    if(!b) break;
                }
                if(b) lists.Add(i);
            }

            if (i != s.Length - charLength)
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
    
    public IList<int> FindSubstring(string s, string[] words)
    {
        IList<int> lists = [];
        int m = words.Length, n = words[0].Length, lenght = s.Length;
        int charLength = m * n;
        if (lenght < charLength) return [];
        

        for (int j = 0; j < lenght-charLength; j++)
        {
            Dictionary<string, int> dic = [];
            foreach (var word in words)
            {
                if (!dic.TryAdd(word, -1)) dic[word]--; 
            }
        
            for (int i = j; i < j+charLength; i += n)
            {
                var word = s.Substring(i, n);
                if (!dic.TryAdd(word, 1))
                {
                    if (++dic[word] == 0) dic.Remove(word);
                }
            }
            if(dic.Count == 0) lists.Add(0);

            for (var i = j; i < s.Length-charLength-n; i+=n)
            {
                var word = s.Substring(i, n);
                if (!dic.TryAdd(word, -1))
                {
                    if (--dic[word] == 0) dic.Remove(word);
                }
                word = s.Substring(i + charLength, n);
                if (!dic.TryAdd(word, 1))
                {
                    if (++dic[word] == 0) dic.Remove(word);
                }
                if(dic.Count == 0) lists.Add(i+n);
            }
        }

        return lists;
            


    }
    
    static void Main(string[] args)
    {
        Program program = new Program();
        string s = "barfoothefoobarman";
        string[] words = ["foo","bar"];
        program.FindSubstring(s, words);
        Console.WriteLine("Hello, World!");
    }
}