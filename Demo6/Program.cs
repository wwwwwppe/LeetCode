namespace Demo6;

class Program
{
    public static string Convert(string s, int numRows)
    {
        int n = s.Length;
        if (numRows == 1 || numRows >n) return s;
        string ret = "";
        int a = numRows * 2 - 2;
        for (int i = 0; i < numRows; i++)
        {
            if (i == 0 || i == numRows - 1)
            {
                int temp = i;
                while (temp < n)
                {
                    ret += s[temp];
                    temp += a;
                }
            }
            else
            {
                int temp = i;
                while (temp < n)
                {
                    ret += s[temp];
                    if(temp+a-i<n)
                        ret += s[temp + a - 2*i];
                    temp += a;
                }
            }
        }

        return ret;
    }

    static void Main(string[] args)
    {
        string s = "PAYPALISHIRING";
        int row = 3;
        Console.WriteLine(Convert(s, row));
    }
}