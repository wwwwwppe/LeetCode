namespace Demo202;

class Program
{
    public bool IsHappy(int n)
    {
        Dictionary<int, int> dictionary = [];
        HashSet<int> hashSet = [];
        for (int i = 0; i < 10; i++)
        {
            dictionary.Add(i, i * i);
        }

        int oriNum = n;
        int newNum = 0;
        while (true)
        {
            while (oriNum > 0)
            {
                newNum += dictionary[oriNum % 10];
                oriNum /= 10;
            }

            if (newNum == 1)
            {
                return true;
            }

            if (!hashSet.Add(newNum))
            {
                return false;
            }

            oriNum = newNum;
            newNum = 0;
        }
    }
    
    public bool IsHappyNew(int n)
    {
        HashSet<int> hashSet = [];
        int fast = n;
        int slow = n;
        do
        {
            slow = Handle(slow);
            fast = Handle(Handle(fast));
        } while (slow != fast);

        return fast == 1;
        
        int Handle(int k)
        {
            int target = 0;
            while (k > 0)
            {
                var temp = k % 10;
                target += temp * temp;
                k /= 10;
            }
            return target;
        }
    }

    static void Main(string[] args)
    {
        Program program = new Program();
        Console.WriteLine(program.IsHappyNew(19));
        Console.WriteLine("Hello, World!");
    }
}