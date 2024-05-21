using System.Collections;

namespace Demo68;

class Program
{
    public static IList<string> FullJustify(string[] words, int maxWidth)
    {
        IList<string> list = [];
        for (var i = 0; i < words.Length; i++)
        {
            int start = i;
            string temp = words[i];
            while (temp.Length < maxWidth && (i + 1) < words.Length)
            {
                temp += words[++i];
                if (temp.Length > maxWidth)
                {
                    --i;
                    break;
                }

                if (temp.Length < maxWidth)
                {
                    temp += " ";
                }
            }

            string temb = temp.Trim();
            if (temb.Length != maxWidth)
            {
                //有多少个间隔
                int a = i - start;
                if (a == 0) a = 1;
                int poor = maxWidth - temb.Length;
                int[] arr = new int[a];
                Array.Fill(arr, 1);
                for (var i1 = 0; i1 < poor; i1++)
                {
                    arr[i1 % a]++;
                }

                var temm = temb.Split(" ");

                temp = "";
                for (int i1 = start; i1 < i; i1++)
                {
                    string b = "";
                    for (int i2 = 0; i2 < arr[i1 - start]; i2++)
                    {
                        b += " ";
                    }

                    temp = words[i1] + b;
                }
            }

            list.Add(temp);
        }

        return list;
    }

    // 一遍AC
    public static IList<string> FullJustifyOne(string[] words, int maxWidth)
    {
        var lists = new List<string>();
        int left = 0, right = 0;
        while (left < words.Length)
        { 
            int temp = 0;
            while (right < words.Length)
            {
                temp += words[right].Length;
                if (temp + right - left > maxWidth)
                {
                    string a = "";
                    temp -= words[right].Length;
                    int cha = maxWidth - temp;
                    right -= 1;
                    int tep = right - left == 0 ? 1 : right - left;
                    int cheng = cha / tep;
                    int ge = cha % tep;
                    for (int i = left; i <= right; i++)
                    {
                        a += words[i];
                        if (tep > 0)
                        {
                            for (int j = 0; j < cheng; j++)
                            {
                                a += " ";
                            }

                            if (ge > 0)
                            {
                                a += " ";
                                ge--;
                            }

                            tep--;
                        }
                    }

                    right++;
                    left = right;
                    lists.Add(a);
                    break;
                }
                else if (right == words.Length - 1)
                {
                    string b = "";
                    for (int i = left; i <= right; i++)
                    {
                        b += words[i];
                        if (b.Length < maxWidth)
                        {
                            b += " ";
                        }
                    }

                    for (int i = b.Length; i < maxWidth; i++)
                    {
                        b += " ";
                    }
                    lists.Add(b);
                    return lists;
                }
                right++;
            }
        }

        return lists;
    }

    public static IList<string> FullJustifyTwo(string[] words, int maxWidth)
    {
        string val = "";
        for (var i = 0; i < words.Length; i++)
        {
            if (val.Length + words[i].Length < maxWidth)
            {
                if (val == "")
                {
                    val += words[i];
                }
                else
                {
                    val += " " + words[i];
                }
            }
            else if (val.Length + words[i].Length == maxWidth)
            {
                if (val == "")
                {
                    val += words[i];
                }
                else
                {
                    //
                }
            }
            else
            {
            }
        }

        return [];
    }

    static void Main(string[] args)
    {
        string[] words =
        [
            "Science", "is", "what", "we", "understand", "well", "enough", "to", "explain", "to", "a", "computer.",
            "Art", "is", "everything", "else", "we", "do"
        ];
        int maxWidth = 20;
        var a = FullJustify(words, maxWidth);

        foreach (var s in a)
        {
            Console.WriteLine(s);
        }
    }
}