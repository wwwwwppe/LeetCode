namespace Demo2739;

class Program
{
    public int DistanceTraveled(int mainTank, int additionalTank)
    {
        int temp = 0;
        while (mainTank - 5 >= 0)
        {
            mainTank -= 5;
            temp += 5;
            if (additionalTank > 0)
            {
                mainTank++;
                additionalTank--;
            }
        }

        return (temp + mainTank) * 10;
    }

    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
    }
}