namespace Demo707;

public class MyLinkedList
{
    class ListNode
    { 
        int val;
        ListNode next;
        ListNode prev;

        internal ListNode(int x)
        {
            val = x;
        }
    }

    private int size;
    private ListNode dummyHead, dummyTail;
    
    public MyLinkedList()
    {
        size = 0;
        dummyHead = new ListNode(0);
        dummyTail = new ListNode(0);
        
        
    }
    
    public int Get(int index)
    {
        
    }
    
    public void AddAtHead(int val) {
        
    }
    
    public void AddAtTail(int val) {

    }
    
    public void AddAtIndex(int index, int val) {

    }
    
    public void DeleteAtIndex(int index) {

    } 
}