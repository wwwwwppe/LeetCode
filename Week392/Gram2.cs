namespace Week392;

public class Gram2
{
    public string GetSmallestString(string s, int k)
    {
        int dump = k;
        string ss = "";
        foreach (var c in s)
        {
            if (dump <= 0)
            {
                ss += c;
            }
            else
            {
                int a = Math.Min(c - 'a', 'z' + 1 - c);
                if (a <= dump)
                {
                    ss += "a";
                    dump -= a;
                }
                else
                {
                    ss += (char)(c - dump);
                    dump = 0;
                }
            }
        }

        return ss;
    } 
}