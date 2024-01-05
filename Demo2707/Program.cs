namespace Demo2707;

class Program
{
    public int MinExtraChar(string s, string[] dictionary)
    {
        int maxLength = 0;

        return s.Length - ReturnSubscript(0);  

        int ReturnSubscript(int init)
        {
            foreach (var t in dictionary)
            {
                for (int i1 = 0,i2 = init; i1 < t.Length&&i2<s.Length; i1++,i2++)
                {
                    if(t[i1] != s[i2]) break;
                    if (i1 == t.Length - 1)
                    {
                        //这里是加上i1的值
                        
                        //这里是不断的递归ReturnSubscript,将i2+1当作参数传入
                        
                    }
                }
            }

            return 0;
        }
    }
    
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
    }
}