namespace Demo495;

class Program
{
    public int FindPoisonedDuration(int[] timeSeries, int duration)
    {
        int max = 0, temp = timeSeries[0];
        for (var i = 1; i < timeSeries.Length; i++)
        {
            if (timeSeries[i] <= temp + duration - 1)
            {
                max += timeSeries[i] - temp;
                temp = timeSeries[i];
            }
            else
            {
                max += duration ;
                temp = timeSeries[i];
            }
        }

        return max + duration;
    }

    public int FindPoisonedDuration1(int[] timeSeries, int duration)
    {
        var query = timeSeries
            .Aggregate((max: 0, temp: timeSeries[0]), 
                (state, next) => next <= state.temp + duration - 1 ? (state.max + next - state.temp, next) : (state.max + duration, next));

        return query.max + duration;
    }
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
    }
}