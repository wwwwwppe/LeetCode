namespace Demo2095;

class Program
{
    public class ListNode
    {
        public int val;
        public ListNode next;

        public ListNode(int val = 0, ListNode next = null)
        {
            this.val = val;
            this.next = next;
        }
    }


    public ListNode DeleteMiddle(ListNode head)
    {
        if (head == null || head.next == null) return null;
        
        ListNode slow =  head;
        ListNode fast =  head;
        ListNode prev = null;

        while (fast != null && fast.next != null)
        {
            prev = slow;
            slow = slow.next;
            fast = fast.next.next;
        }

        prev.next = slow.next;
        return head;
    }
    
    //错误的，让后面自己来看，不删除
    public ListNode DeleteMiddleDemo(ListNode head)
    {
        int n = 1;
        ListNode current = new ListNode();
        while (head != null && head.val != null && head.next != null)
        {
            current.val = head.val;
            current.next = head.next;
            head = head.next;
            n++;
        }

        int midNum = n / 2;
        int nn = 1;

        ListNode middle = new ListNode();
        while (current != null && current.val != null && current.next != null)
        {
            if (nn == midNum)
            {
                middle.val = current.next.val;
                middle.next = current.next.next;
                current =  current.next.next;
            }
            else
            {
                middle.val = current.val;
                middle.next = current.next;
                current = current.next;
            }
        }

        return middle;
    }

    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
    }
}