namespace Demo2671;

public class FrequencyTracker
{
    private Dictionary<int, int> _dictionary;
    
    public FrequencyTracker()
    {
        _dictionary = new Dictionary<int, int>();
    }
    
    public void Add(int number)
    {
        if (!_dictionary.TryAdd(number, 1))
        {
            _dictionary[number]++;
        }
    }
    
    public void DeleteOne(int number) {
        if (_dictionary.TryGetValue(number, out int val))
        {
            if (val == 1) _dictionary.Remove(number);
            else _dictionary[number]--;
        }
    }
    
    public bool HasFrequency(int frequency)
    {
        return _dictionary.ContainsValue(frequency);
    } 
}