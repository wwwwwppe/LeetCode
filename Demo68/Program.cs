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