namespace Demo2391;

class Program
{
    public int GarbageCollection(string[] garbage, int[] travel)
    {
        int n = garbage.Length;
        int ret = 0;
        int rightM =0, rightP=0, rightG=0;
        for (var i = garbage.Length - 1; i >= 0; i--)
        {
            if (!garbage[i].Contains('M')) continue;
            rightM = i;
            break;
        }
        
        for (var i = garbage.Length - 1; i >= 0; i--)
        {
            if (!garbage[i].Contains('P')) continue;
            rightP = i;
            break; 
        }
        
        for (var i = garbage.Length - 1; i >= 0; i--)
        {
            if (!garbage[i].Contains('G')) continue;
            rightG = i;
            break; 
        }

        int[] times = new int[travel.Length + 1];
        times[0] = 0;
        for (var i = 1; i < times.Length; i++)
        {
            times[i] = times[i - 1] + travel[i - 1];
        }

        ret += times[rightM] + times[rightP] + times[rightG];

        ret += garbage.Sum(x => x.Length);
        return ret;

    }
    
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
    }
}