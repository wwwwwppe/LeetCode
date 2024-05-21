namespace Demo1146;

public class SnapshotArrayTwo
{
    private int seq_id;
    private List<Tuple<int, int>>[] lists;

    public SnapshotArrayTwo(int length)
    {
        seq_id = 0;
        lists = new List<Tuple<int, int>>[length];
        for (int i = 0; i < length; i++)
        {
            lists[i] = [];
        }
    }

    public void Set(int index, int val)
    {
        lists[index].Add(new Tuple<int, int>(seq_id,val));
    }

    public int Snap()
    {
        return seq_id++;
    }

    public int Get(int index, int snap_id)
    {
        for (var i = lists[index].Count - 1; i >= 0; i--)
        {
            if (lists[index][i].Item1 <= snap_id) return lists[index][i].Item2;
        }

        return 0;
    }
}