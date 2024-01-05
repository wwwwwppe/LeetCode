namespace Demo2487;

class Program
{
    public ListNode RemoveNodes(ListNode head)
    {
        List<int> lists = new List<int>();
        while (head != null)
        {
            lists.Add(head.val);
            head = head.next;
        }

        return null;
    }
    
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
    }
}