namespace Demo2660;

class Program
{
    public int IsWinner(int[] player1, int[] player2) {
        int sumOneOri = player1.Sum();
        int sumTwoOri = player2.Sum();
        if (player1.Length > 1 && player2.Length > 1)
        {
            if (player1[0] == 10) sumOneOri += player1[1];
            if (player2[0] == 10) sumTwoOri += player2[1];
            for (int i = 2; i < player1.Length; i++)
                if (player1[i - 1] == 10 || player1[i - 2] == 10) sumOneOri += player1[i];
            for (int i = 2; i < player2.Length; i++)
                if (player2[i - 1] == 10 || player2[i - 2] == 10) sumTwoOri += player2[i];
        }
        return sumOneOri > sumTwoOri ? 1 : sumOneOri == sumTwoOri ? 0 : 2;
    }
    
    static void Main(string[] args)
    {
           
    }
}