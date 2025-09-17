namespace Demo334;

class Program
{
    public bool IncreasingTriplet(int[] nums)
    {
        List<int> l = new List<int>();
        foreach (var t in nums)
        {
            if(l.Count == 0) l.Add(t);
            if (l.Count == 1)
            {
                if(t < l[0]) l[0] = t;
                else if(t > l[0]) l.Add(t);
            }

            if (l.Count == 2)
            {
                if (t < l[1] && t > l[0]) l[1] = t;
                if(t < l[0])  l[0] = t;
                if (t > l[1]) return true;
            }
        }

        return false;
    }
    
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
    }
}