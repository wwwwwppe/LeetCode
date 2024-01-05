using System.Text;

namespace Demo2075;

class Program
{
    public string DecodeCiphertext(string encodedText, int rows)
    {
        char[] original = encodedText.ToCharArray();
        int length = encodedText.Length;
        int n = length / rows;
        Console.WriteLine(n);
        char[][] lists = new char[rows][];
        for (int i = 0; i < rows; i++)
        {
            lists[i] = new char[n];
            for (int i1 = 0; i1 < n; i1++)
            {
                lists[i][i1] = original[i * n + i1];
            }
        }

        StringBuilder stringBuilder = new StringBuilder();
        for (int i = 0; i <= n - rows; i++)
        {
            for (int j = 0; j < rows; j++)
            {
                stringBuilder.Append(lists[j][i + j]);
            }
        }

        return stringBuilder.ToString();
    }

    static void Main(string[] args)
    {
        string encodedText = "iveo    eed   l te   olc";
        Program program = new Program();
        Console.WriteLine(program.DecodeCiphertext(encodedText, 4));
    }
}