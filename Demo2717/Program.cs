namespace Demo2717;

class Program
{    
    public int SemiOrderedPermutation(int[] nums) {
        int length = nums.Length;
        int index1 = Array.IndexOf(nums,1);
        int indexLength = Array.LastIndexOf(nums,length);
        int ret = index1 + (length - indexLength - 1);

        if(ret + 2 > length){
          ret -= 1;
        }

        return ret;
    }

    public int SemiOrderedPermutationOri(int[] nums) {
        int ret = 0;
        int length = nums.Length;
        for (int i = 0; i < length; i++)
        {
            if(nums[i] == 1){
              ret += i;
              break;
            }
        }

        for (int i = length - 1; i >= 0 ; i--)
        {
            if(nums[i] == length){
                int right = length - i - 1;
                if(right + ret + 2 > length){
                    ret += right - 1;
                }else {
                    ret += right;
                }
              break;
            }
        }

        return ret;
    }
    
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
    }
}
