using System.Text;

namespace Demo394;

public class DecodeStringDemo
{
    public string DecodeStringTwo(string s)
    {
        while (TryDecodeOne(ref s)) { }
        return s;
    }

    private bool TryDecodeOne(ref string s)
    {
        int leftBracket = s.LastIndexOf('[');
        if (leftBracket < 0) return false;
        int rightBracket = s.IndexOf(']',leftBracket + 1);
        if (rightBracket < 0) return false;

        int repeatStart = leftBracket - 1;
        while (repeatStart >= 0 && char.IsDigit(s[repeatStart]))
        {
            repeatStart--;
        }
        repeatStart++;

        if (repeatStart == leftBracket) return false;
        
        int repeat = int.Parse(s.AsSpan(repeatStart, leftBracket - repeatStart));
        ReadOnlySpan<char> segment = s.AsSpan(leftBracket + 1 , rightBracket - leftBracket - 1);

        var sb = new StringBuilder(segment.Length * repeat);
        for (int i = 0; i < repeat; i++)
            sb.Append(segment);
        
        //拼接：前缀+展开+后缀
        string expanded = sb.ToString();
        s = string.Concat(
            s.AsSpan(0,repeatStart),
            expanded,
            s.AsSpan(rightBracket + 1)
        );
        return true;
    }
}