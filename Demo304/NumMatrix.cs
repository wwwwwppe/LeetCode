namespace Demo304;

public class NumMatrix
{
    private int[][] newMatrix;

    public NumMatrix(int[][] matrix)
    {
        newMatrix = new int[matrix.Length + 1][];
        newMatrix[0] = new int[matrix[0].Length+1];
        for (var i = 1; i < newMatrix.Length; i++)
        {
            int[] ints = new int[matrix[0].Length+1];
            int sum = 0;
            for (var i1 = 1; i1 < ints.Length; i1++)
            {
                sum += matrix[i - 1][i1-1];
                ints[i1] = sum + newMatrix[i - 1][i1];
            }

            newMatrix[i] = ints;
        }
    }

    public int SumRegion(int row1, int col1, int row2, int col2)
    {
        var sum = newMatrix[row2 + 1][col2 + 1] - newMatrix[row1][col2 + 1] - newMatrix[row2+1][col1] +
                  newMatrix[row1][col1];
        return sum;
    }
}