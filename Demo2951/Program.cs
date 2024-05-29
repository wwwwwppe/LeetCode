namespace Demo2951;

class Program
{
    public IList<int> FindPeaks(int[] mountain)
    {
        IList<int> lists = [];
        var isMaxBefore = false;
        for (var j = 1; j < mountain.Length; j++)
        {
            if (mountain[j] < mountain[j-1])
            {
                if(j>1 && isMaxBefore)
                    lists.Add(j-1);
            } 
            if(mountain[j] > mountain[j-1])
            {
                isMaxBefore = true;
            }
            else
            {
                isMaxBefore = false;
            }
        }

        return lists;
    }
    
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
    }
}