namespace LCP61;

class Program
{
    public int TemperatureTrend(int[] temperatureA, int[] temperatureB)
    {
        int max = 0;
        if (temperatureB.Length != temperatureA.Length)
        {
            return max;
        }

        int temp = 0;
        for (var i = 0; i < temperatureA.Length - 1; i++)
        {
            if (Math.Sign(temperatureA[i+1] - temperatureA[i]) == Math.Sign(temperatureB[i+1] - temperatureB[i]))
            {
                temp++;
            }
            else
            {
                temp = 0;
            }
            max = Math.Max(max, temp);
        }
        
        return max;
    }
    
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
    }
}