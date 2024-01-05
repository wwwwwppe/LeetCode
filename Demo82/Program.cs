namespace Demo82;

class Program
{
    public class ListNode
    {
        public int val;
        public ListNode? next;
        public ListNode(int val = 0, ListNode? next = null)
        {
            this.val = val;
            this.next = next;
        }

        public void Add(int value)
        {
            ListNode newListNode = new ListNode(value);
            ListNode temp = this;

            while (temp.next != null)
            {
                temp = temp.next;
            }

            temp.next = newListNode;
        }

        public void Cw()
        {
            ListNode temp = this;
            while (temp != null)
            {
                Console.WriteLine(temp.val);
                temp = temp.next;
            }
        }
    }

    public ListNode DeleteDuplicates(ListNode? head)
    {
        Dictionary<int, int> dictionary = new Dictionary<int, int>();
        Stack<int> stack = new Stack<int>();
        while (head != null)
        {
            if (dictionary.TryAdd(head.val,0))
            {
                stack.Push(head.val);
            }
            else
            {
                dictionary[head.val] += 1;
            }
            head = head.next;
        }

        ListNode list = new ListNode(stack.Pop());
        ListNode tail = list;
        
        while (stack.Count > 0)
        {
            int key = stack.Pop();
            
            if(dictionary.TryGetValue(key, out int outInt) && outInt == 0) {

                ListNode node = new ListNode(key);
    
                tail.next = node;
                tail = node; 
            }
        }

        list.Cw();
        return Reverse(list);
        
        ListNode Reverse(ListNode head) {

            if(head == null || head.next == null) {
                return head;
            }

            ListNode newHead = null;

            while(head != null) {
                ListNode nextNode = head.next;
                head.next = newHead;
                newHead = head; 
                head = nextNode;
            }

            return newHead;
        }
    }

    
    static void Main(string[] args)
    {
        ListNode a = new ListNode(1);
        a.Add(2);
        a.Add(3);
        a.Add(3);
        a.Add(4);
        a.Add(4);
        a.Add(5);
        Program program = new Program();
        ListNode b = program.DeleteDuplicates(a);
    }
}