namespace Demo2024;

class Program
{

    public static int MaxConsecutiveAnswers(string answerKey, int k)
    {
        var ret=0;
        
        MaxConsecutive('T');
        MaxConsecutive('F');
        
        return ret;
        
        void MaxConsecutive(char ch)
        {
            var length = answerKey.Length;
            for (int l = 0, r = 0,sum=0; r < length; r++)
            {
                sum += answerKey[r] == ch ? 0 : 1;
                while (sum>k)
                {
                    sum -= answerKey[l++] == ch ? 0 : 1;
                }
                ret = Math.Max(ret, r - l + 1);
            }
        }
    }

    /*public static int MaxConsecutive(string answerKey, int k, char ch)
    {
        int length = answerKey.Length;
        int ret = 0;
        for (int l = 0, r = 0,sum=0; r < length; r++)
        {
            sum += answerKey[r] == ch ? 0 : 1;
            while (sum>k)
            {
                sum -= answerKey[l++] == ch ? 0 : 1;
            }

            ret = Math.Max(ret, r - l + 1);
        }

        return ret;
    }*/
    
    //会超时，因为只存在两种情况，所以可以在只匹配两种
    public static int MaxConsecutiveAnswersOri(string answerKey, int k)
    {
        if(answerKey.Length == 1) return 1;
        int l = 0, r = 0, d = 0;
        int ret = 0;
        var ans =  answerKey.ToCharArray();
        for (; l < answerKey.Length-1; l++)
        {
            r = l;
            int c = k;
            char tip = 'T';
            d = l;
            while (r<answerKey.Length&&c>=0)
            {
                if (ans[r] == tip) r++;
                else if (c == k)
                {
                    l = r-1;
                    r++;
                    c--;
                }
                else if (c != 0)
                {
                    r++;
                    c--;
                }
                else
                    c--;
                    
            }

            ret = Math.Max(ret, r - d);
            if ((r-d)==ret&&c > 0 && r == answerKey.Length)
                ret = (ret + c) > answerKey.Length ? answerKey.Length : (ret + c);
        }

        return ret;
    }
    
    static void Main(string[] args)
    {
        String s = "FFFTTFTTFT";
        int a = MaxConsecutiveAnswers(s,3);
        Console.WriteLine(a);
    }
}