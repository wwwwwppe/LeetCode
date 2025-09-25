namespace Demo649;

public class PredictPartyVictoryQueue
{
    public string PredictPartyVictory(string senate)
    {
        int n = senate.Length;
        var rQueue = new Queue<int>();
        var dQueue = new Queue<int>();
        for (int i = 0; i < n; i++)
        {
            if (senate[i] == 'R')
            {
                rQueue.Enqueue(i);
            }
            else
            {
                dQueue.Enqueue(i);
            }
        }

        while (rQueue.Count > 0 && dQueue.Count > 0)
        {
            var r = rQueue.Dequeue();
            var d = dQueue.Dequeue();
            if (r < d)
            {
                rQueue.Enqueue(r+n);
            }
            else
            {
                dQueue.Enqueue(d+n);
            }
        }
        return rQueue.Count > 0 ? "Radiant":"Dire";
    }
}