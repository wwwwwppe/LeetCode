namespace Demo1702;

class Program
{
    public string MaximumBinaryString(string binary)
    {
        if(binary.Length<3) return binary;
        var c = binary.ToCharArray();
        int left = 0;
        for (; left < c.Length; left++)
        {
            if(c[left]!='1') break;
        }

        int  b = 0;
        for (var i = left; i < c.Length; i++)
        {
            if (c[i] == '0') b++;
        }
        
        for (var i = left; i < c.Length; i++)
        {
            c[i] = '1';
            if (b > 0)
            {
                b--;
                if(b==0) c[i] = '0';
            }
        }

        return new string(c);
    }

    static void Main(string[] args)
    {
        Program program = new Program();
        string binary = "000110";
        Console.WriteLine(program.MaximumBinaryString(binary));
    }
}