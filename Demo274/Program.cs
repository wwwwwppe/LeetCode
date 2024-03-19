namespace Demo274;

class Program
{
    public int HIndex(int[] citations)
    {
        Array.Sort(citations,(x1,x2)=>x2-x1);
        int h = citations.Length>1000?1000:citations.Length;
        for (; h > 0; h--)
        {
            if (citations[h - 1] >= h)
            {
                break;
            }
        }

        return h;
    }
    
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
    }
}