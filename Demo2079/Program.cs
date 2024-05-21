namespace Demo2079;

class Program
{
    public int WateringPlants(int[] plants, int capacity)
    {
        int ret = 0;
        int left = 0,water = capacity;
        while (left < plants.Length)
        {
            if (left != plants.Length - 1 && water - plants[left] >= plants[left+1])
            {
                ret++;
                water -= plants[left];
            }
            else if(left != plants.Length-1)
            {
                ret += 2 * left + 3;
                water = capacity;
            }
            left++;
        }

        return ++ret;
    }
    
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
    }
}