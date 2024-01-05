namespace Demo2645;

class Program
{
    public int AddMinimum(string word)
    {
        var num = word[0] - 'a';
        for (var i = 0; i < word.Length-1; i++)
        {
            num += Computed(word[i + 1] - word[i]);
        }
        num += 'c'-word[^1];
        return num;
        
        int Computed(int init)
        {
            return (init + 2) % 3;
        }
    }


    
    public int AddMinimumOri(string word)
    {
        int a = 0, b = 0, c = 0;
        for (var i = 0; i < word.Length-1; i++)
        {
            if (word[i] == 'a')
            {
                if (word[i + 1] == 'c') b++;
                if (word[i + 1] == 'a')
                {
                    b++;
                    c++;
                }
            }

            if (word[i] == 'b')
            {
                if (word[i + 1] == 'a') c++;
                if (word[i + 1] == 'b')
                {
                    c++;
                    a++;
                }
            }

            if (word[i] == 'c')
            {
                if (word[i + 1] == 'b') a++;
                if (word[i + 1] == 'c')
                {
                    a++;
                    b++;
                }
            }
        }

        if (word[0] == 'b') a++;
        if (word[0] == 'c')
        {
            a++;
            b++;
        }

        if (word[^1] == 'a')
        {
            b++;
            c++;
        }

        if (word[^1] == 'b') c++;

        return a + b + c;
    }
    
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
    }
}