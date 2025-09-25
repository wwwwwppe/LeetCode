namespace Demo649;

class Program
{
    public string PredictPartyVictory(string senate)
    {
        var senates = senate.ToCharArray();
        bool a = true;

        while (a)
        {
            a = false;
            //如果被投失去权利为O，当最后一轮只存在O和R或D，则判断R或者D赢。
            for (var i = 0; i < senates.Length; i++)
            {
                if (senates[i] == 'R')
                {
                    int j = i;
                    for (; j < senates.Length + i; j++)
                    {
                        if (senates[j%senates.Length] == 'D')
                        {
                            senates[j%senates.Length] = 'O';
                            a = true;
                            break;
                        }
                    }
                }

                else if (senates[i] == 'D')
                {
                    int j = i;
                    for (; j < senates.Length + i; j++)
                    {
                        if (senates[j%senates.Length] == 'R')
                        {
                            senates[j%senates.Length] = 'O';
                            a = true;
                            break;
                        }
                    }
                }
            }
        }
        
        for (var i = 0; i < senates.Length; i++)
        {
            if (senates[i] == 'R') return "Radiant";
            if (senates[i] == 'D') return "Dire";
        }

        return ""; 
    }

    
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
    }
}