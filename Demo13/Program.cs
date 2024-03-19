namespace Demo13;

class Program
{
    public int RomanToInt(string s)
    {
        int sum = 0;
        Dictionary<char, int> dic = new Dictionary<char, int>
        {
            {'I', 1},
            {'V', 5},
            {'X', 10},
            {'L', 50},
            {'C', 100},
            {'D', 500},
            {'M', 1000}
        };

        var strs = s.ToCharArray();
        for (var i = 0; i < strs.Length-1; i++)
        {
            if (dic[strs[i]] < dic[strs[i + 1]])
            {
                sum -= dic[strs[i]];
            }
            else
            {
                sum += dic[strs[i]];
            }
        }

        sum += dic[strs[^1]];

        return sum;



    }
    
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
    }
}