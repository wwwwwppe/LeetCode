namespace Demo590;

public class RandomizedSet
{
    private List<int> lists;
    private Dictionary<int,int> dic;
    private HashSet<int> HashSet;
    private Random random;
    
    public RandomizedSet()
    {
        lists = new List<int>();
        dic = new Dictionary<int, int>();
        HashSet = new HashSet<int>();
        random = new Random();
    }
    
    public bool Insert(int val)
    {
        if (lists.Contains(val)) return false;
        lists.Add(val);
        return true;
    }
    
    public bool Remove(int val)
    {
        if (!lists.Contains(val)) return false;
        lists.Remove(val);
        return true;
    }
    
    public int GetRandom()
    {
        return lists[random.Next(0, lists.Count)];
    } 
}