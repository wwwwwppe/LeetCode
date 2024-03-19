namespace Demo232;

public class MyQueue
{
    private Stack<int> isStack;
    private Stack<int> outStack;
    
    public MyQueue()
    {
        isStack = [];
        outStack = [];
    }
    
    public void Push(int x) {
        isStack.Push(x);
    }
    
    public int Pop() {
        if (outStack.Count == 0)
        {
            InAndOut();
        }

        return outStack.Pop();
    }
    
    public int Peek() {
        if (outStack.Count == 0)
        {
            InAndOut();
        }

        return outStack.Peek();
    }
    
    public bool Empty()
    {
        return isStack.Count == 0 && outStack.Count == 0;
    }

    private void InAndOut()
    {
        while (isStack.Count>0)
        {
            outStack.Push(isStack.Pop());
        }
    }
}