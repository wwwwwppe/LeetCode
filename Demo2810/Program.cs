namespace Demo2810;

class Program
{
    public String finalString(String s)
    {
        string a = "";
        foreach (var c in s)
        {
            if (c != 'i')
            {
                a += c;
            }
            else
            {
                Swap();
            }
        }

        return new string(a.Reverse().ToArray());


        void Swap()
        {
            string b = "";
            for (var i = a.Length - 1; i >= 0; i--)
            {
                b += a[i];
            }

            a = b;
        }
    }


    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
    }
}