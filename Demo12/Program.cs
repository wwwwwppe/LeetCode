namespace Demo12;

class Program
{
    public string IntToRoman(int num)
    {
        string ret = "";
        int[] ints = [1000, 900, 500, 400, 100, 90, 50, 40, 10, 9,5, 4, 1];
        Dictionary<int,string> strs = new Dictionary<int, string>
        {
            {1000, "M"},
            {900, "CM"},
            {500, "D"},
            {400, "CD"},
            {100, "C"},
            {90, "XC"},
            {50, "L"},
            {40, "XL"},
            {10, "X"},
            {9, "IX"},
            {5, "V"},
            {4, "IV"},
            {1, "I"}
        };
        
        foreach (var i in ints)
        {
            while (num>=i)
            {
                num -= i;
                ret += strs[i];
            }
        }

        return ret;
    }
    
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
    }
}