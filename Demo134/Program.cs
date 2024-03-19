namespace Demo134;

class Program
{

    public static int CanCompleteCircuit(int[] gas, int[] cost)
    {
        if (gas.Length != cost.Length) return -1;
        int n = gas.Length;
        if (gas.Sum() < cost.Sum()) return -1;
        for (int i = 0; i < n; i++)
        {
            bool a = true;
            int sum = 0;
            for (int j = 0; j < n; j++)
            {
                int t = (i+j) % n;
                sum += gas[t] - cost[t];
                if (sum < 0)
                {
                    i = t;
                    a = false;
                    break;
                }
            }
            if(a) return i;
        }

        return -1;
    }
    
    //会超时
    public static int CanCompleteCircuitTwo(int[] gas, int[] cost)
    {
        int n = gas.Length;
        if (gas.Length != cost.Length) return -1;
        if (gas.Sum() < cost.Sum()) return -1;
        List<int> list = [];
        for (var i = 0; i < gas.Length; i++)
        {
            if(gas[i]>=cost[i]) list.Add(i);
        }
        for (var i = 0; i < list.Count; i++)
        {
            int sum = 0;
            bool a = true;
            for (var i1 = 0; i1 < gas.Length; i1++)
            {
                int temp = (list[i] + i1) % n;
                sum += gas[temp] - cost[temp];
                if (sum < 0)
                {
                    a = false;
                    break;
                }
            }

            if (a) return list[i];
        }

        return -1;
    }
    
    static void Main(string[] args)
    {
        int[] gas = [1, 2, 3, 4, 5];
        int[] cost = [3, 4, 5, 1, 2];
        Console.WriteLine(CanCompleteCircuit(gas,cost));
    }
}