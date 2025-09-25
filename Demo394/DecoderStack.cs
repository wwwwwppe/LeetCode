using System.Text;

namespace Demo394;

public class DecoderStack
{
     public static string Decode(string s)
    {
        int[] numStackArr = new int[64]; // Small input optimization (can overflow to List)
        StringBuilder[] strStackArr = new StringBuilder[64];
        List<int>? numStackList = null;
        List<StringBuilder>? strStackList = null;
        int depth = 0;

        int curNum = 0;
        var cur = new StringBuilder();

        for (int i = 0; i < s.Length; i++)
        {
            char c = s[i];
            if ((uint)(c - '0') <= 9)
            {
                curNum = curNum * 10 + (c - '0');
            }
            else if (c == '[')
            {
                EnsurePush(ref numStackArr, ref numStackList, ref strStackArr, ref strStackList, depth, curNum, cur);
                depth++;
                curNum = 0;
                cur = new StringBuilder();
            }
            else if (c == ']')
            {
                depth--;
                int repeat = DepthGetInt(numStackArr, numStackList, depth);
                var prev = DepthGetStringBuilder(strStackArr, strStackList, depth);
                for (int r = 0; r < repeat; r++)
                    prev.Append(cur);
                cur = prev;
            }
            else
            {
                cur.Append(c);
            }
        }
        return cur.ToString();

        static void EnsurePush(ref int[] numArr, ref List<int>? numList,
                               ref StringBuilder[] strArr, ref List<StringBuilder>? strList,
                               int depth, int num, StringBuilder sb)
        {
            if (depth < numArr.Length)
            {
                numArr[depth] = num;
                strArr[depth] = sb;
            }
            else
            {
                numList ??= new List<int>(numArr);
                strList ??= new List<StringBuilder>(strArr);
                numList.Add(num);
                strList.Add(sb);
            }
        }

        static int DepthGetInt(int[] arr, List<int>? list, int depth)
            => depth < arr.Length ? arr[depth] : list![depth];

        static StringBuilder DepthGetStringBuilder(StringBuilder[] arr, List<StringBuilder>? list, int depth)
            => depth < arr.Length ? arr[depth] : list![depth];
    } 
}