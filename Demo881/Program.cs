namespace Demo881;

class Program
{
    public int NumRescueBoats(int[] people, int limit)
    {
        Array.Sort(people);
        int left = 0, right = people.Length - 1;
        int sum = 0;
        while (right>0)
        {
            if (people[right] >= limit)
            {
                sum++;
                right--;
            }
            else
            {
                break;
                
            }
        }
        while (left <= right)
        {
            if (people[left] + people[right] <= limit)
            {
                sum++;
                left++;
                right--;
            }
            else
            {
                sum++;
                right--;
            }
        }

        return sum;
    }

    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
    }
}