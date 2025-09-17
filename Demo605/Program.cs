namespace Demo605;

class Program
{
    public bool CanPlaceFlowers(int[] flowerbed, int n) {

        int num = flowerbed.Sum();

        flowerbed[0] = 1;
        for (int i = 1; i < flowerbed.Length; i++)
        {
            if (flowerbed[i - 1] == 1) continue;
            flowerbed[i] = 1;
        }

        for (int i = flowerbed.Length - 1; i > 0; i--)
        {
            if (flowerbed[i] == 1 && flowerbed[i - 1] == 1)
            {
                flowerbed[i] = 0;
            }
        }

        return flowerbed.Sum() - num >= n;
    }
    
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
    }
}