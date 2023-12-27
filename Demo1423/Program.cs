// See https://aka.ms/new-console-template for more information

namespace Demo1423
{
    class Program
    {
        public int MaxScore(int[] cardPoints, int k)
        {
            // 获取还剩下的长度
            var beLeftOverLong = cardPoints.Length - k;
            // 获取前面的和
            var num = cardPoints.Take(beLeftOverLong).Sum();

            var maxNum = num;
            for (var i = 0; i < k; i++)
            {
                num = num - cardPoints[i] + cardPoints[i + beLeftOverLong];
                maxNum = Math.Min(maxNum, num);
            }

            return cardPoints.Sum() - maxNum;
        }
        
        static void Main(string[] args)
        {
            int[] arr = { 96, 90, 41, 82, 39, 74, 64, 50, 30 };
            Console.WriteLine(arr.Sum());
        }
    }
}