namespace Demo2207;

class Program
{
    public long MaximumSubsequenceCountOri(string text, string pattern)
    {
        int a = text.IndexOf(pattern[0]);
        int b = text.LastIndexOf(pattern[1]);
        List<long> lists = [];
        if (a == -1 && b == -1)
            return 0;
        if (a == -1)
            return text.Count(c => c == pattern[1]);
        if (b == -1)
            return text.Count(c => c == pattern[0]);

        //这里要做处理,如果缺少一边的话，不一定为0
        bool aa = true;
        long temp = 0;
        for (var i = a; i <= b; i++)
        {
            if ((text[i] == pattern[0] && aa) || (text[i] == pattern[1] && !aa))
            {
                temp++;
            }
            else if ((text[i] == pattern[0] && !aa) || (text[i] == pattern[1] && aa))
            {
                aa = !aa;
                lists.Add(temp);
                temp = 1;
            }
        }
        if (temp != 0)
            lists.Add(temp);
        long preLeft = 0,
            preRigth = 0;
        for (int i = 0; i < lists.Count; i++)
        {
            if (i % 2 == 0)
            {
                preLeft += lists[i];
            }
            else
            {
                preRigth += lists[i];
            }
        }

        //两边都加一，看看那边最后结果大
        preLeft++;
        preRigth++;

        long ret1 = 0,
            ret2 = 0;

        for (int l = 0; l < lists.Count; l++)
        {
            if (l % 2 == 0)
            {
                ret1 += lists[l] * preRigth;
            }
            else
            {
                preRigth -= lists[l];
            }
        }

        for (int i = lists.Count - 1; i >= 0; i--)
        {
            if (i % 2 == 1)
            {
                ret2 += lists[i] * preLeft;
            }
            else
            {
                preLeft -= lists[i];
            }
        }

        return Math.Max(ret1, ret2);
    }
    
    public long MaximumSubsequenceCount(string text, string pattern) {
        long res = 0, cnt1 = 0, cnt2 = 0;
        foreach (char c in text) {
            if (c == pattern[1]) {
                res += cnt1;
                cnt2++;
            }
            if (c == pattern[0]) {
                cnt1++;
            }
        }
        return res + Math.Max(cnt1, cnt2);
    }

    static void Main(string[] args)
    {
        Program program = new Program();
        string text = "iuvgbmteyivbfwuospxmmgzagfa";
        string p = "ti";
        program.MaximumSubsequenceCount(text, p);
    }
}
