namespace Demo2671;

class Program
{
    static void Main(string[] args)
    {
        FrequencyTracker frequencyTracker = new FrequencyTracker();
        frequencyTracker.Add(3);
        frequencyTracker.Add(3);
        frequencyTracker.HasFrequency(2);
    }
}