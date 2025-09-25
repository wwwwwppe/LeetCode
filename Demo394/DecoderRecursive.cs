using System.Text;

namespace Demo394;

public class DecoderRecursive
{
    public static string Decode(string s)
    {
        int i = 0;
        return Parse(s, ref i).ToString();
    }

    private static StringBuilder Parse(string s, ref int i)
    {
        var sb = new StringBuilder();
        int num = 0;
        while (i < s.Length)
        {
            char c = s[i];
            if ((uint)(c - '0') <= 9)
            {
                num = num * 10 + (c - '0');
                i++;
            }
            else if (c == '[')
            {
                i++;
                var inner = Parse(s, ref i);
                for (int r = 0; r < num; r++)
                    sb.Append(inner);
                num = 0;
            }
            else if (c == ']')
            {
                i++;
                break;
            }
            else
            {
                sb.Append(c);
                i++;
            }
        }
        return sb;
    } 
}