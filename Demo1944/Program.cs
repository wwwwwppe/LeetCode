namespace Demo1944;

class Program
{
    //这个是优化后的代码
    public int[] CanSeePersonsCount(int[] heights)
    {
        int[] lists = new int[heights.Length];
        Stack<int> stack = new Stack<int>();
        for (var i = heights.Length - 1; i >= 0; i--)
        {
            while (stack is { Count: > 0 } && heights[i] > stack.Peek())
            {
                lists[i]++;
                stack.Pop();
            }

            if (stack is { Count: > 0 })
                lists[i]++;
            stack?.Push(heights[i]);
        }
        return lists;
    }
    //判断右边是否单调
    /*
    private int[] judegeArray(int[] heights, int x)
    {
        List<int> list = new List<int>();
        for (;x < heights.Length; x++)
        {
            if()
        }
    }
    */

    //试试单调栈
    public int[] monotoneStack(int[] heights)
    {
        int[] lists = new int[heights.Length];
        lists[^1] = 0;
        //从右到作
        Stack<int> stack = new Stack<int>();
        stack.Push(heights[^1]);
        for (var i = heights.Length - 2; i >= 0; i--)
        {
            Stack<int> newStack = new Stack<int>();
            while (stack is { Count: > 0 } && heights[i] > stack.Peek())
            {
                newStack.Push(stack.Pop());
            }

            if (stack is { Count: > 0 })
                lists[i] = newStack.Count + 1;
            else if (stack is { Count: 0 })
                lists[i] = newStack.Count;
            stack?.Push(heights[i]);
        }

        return lists;
    }

    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
    }
}