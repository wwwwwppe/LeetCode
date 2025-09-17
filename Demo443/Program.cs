namespace Demo443;

class Program
{
    public int Compress(char[] chars) {
        char first =  chars[0];
        int num = 1;
        List<char> list = new List<char>();
        for (int i = 1; i < chars.Length; i++)
        {
            if (chars[i] == first)
            {
                num++;
            }
            else
            {
                list.Add(first);
                if (num > 1)
                {
                    foreach (var c in num.ToString())
                        list.Add(c); 
                }
                num = 1;
                first = chars[i];
            }
        }

        list.Add(first);
        if (num > 1)
        {
            foreach (var c in num.ToString())
                list.Add(c);
        }
        
        for (int i = 0; i < list.Count; i++)
            chars[i] = list[i];
        
        return list.Count;
    }
    
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
    }
}