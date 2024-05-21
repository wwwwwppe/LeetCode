namespace Demo1146;

public class SnapshotArray
{
    private int[] _array;
    private int _snapId;
    private List<List<int[]>> _snapIds;
    private List<int[]> _ints;
    
    public SnapshotArray(int length)
    {
        _array = new int[length];
        _snapIds = [];
        _ints = [];
        _snapId = 0;
    }
    
    public void Set(int index, int val)
    {
        _array[index] = val;
        _ints.Add([index, val]);
    }
    
    public int Snap()
    {
        List<int[]> demp = [];
        foreach (var intse in _ints)
        {
            int[] a = new int[intse.Length];
            for (var i = 0; i < intse.Length; i++)
            {
                a[i] = intse[i];
            }
            demp.Add(a);
        }
        _snapIds.Add(demp);
        _ints.Clear();
        return _snapId++;
    }
    
    public int Get(int index, int snap_id)
    {
        for (int i = snap_id; i >= 0; i--)
        {
            for (var i1 = _snapIds[i].Count - 1; i1 >= 0; i1--)
            {
                if (_snapIds[i][i1][0] == index) return _snapIds[i][i1][1];
            }
        }

        return 0;
    } 
}