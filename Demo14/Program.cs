namespace Demo14;

class Program
{
    public string LongestCommonPrefix(string[] strs)
    {
        string ret = "";
        bool a = false;
        for (var i = 0; i < strs[0].Length; i++)
        {
            foreach (var str in strs)
            {
                if (str.Length <= i || str[i] != strs[0][i])
                {
                    a = true;
                    break;
                }
            }

            if (a) break;

            ret += strs[0][i];
        }

        return ret;
    }


    //改版
    public string LongestCommonPrefixG(string[] strs)
    {
        string ret = "";
        for (var i = 0; i < strs[0].Length; i++)
        {
            if (strs.Any(str => str.Length <= i || str[i] != strs[0][i]))
                break;
            ret += strs[0][i];
        }
        return ret;
    }

    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
    }
}