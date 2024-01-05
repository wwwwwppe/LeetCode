using System.Collections;

namespace Demo15;

class Program
{
    public IList<IList<int>> ThreeSum(int[] nums)
    {
        Array.Sort(nums);
        IList<IList<int>> lists = new List<IList<int>>();
        var demo = Math.Pow(10,5)+1;
        for (int i = 0; i < nums.Length-2; i++)
        {
            if(nums[i] == demo) continue;
            demo = nums[i];
            int left = i+1,right = nums.Length -1;
            while(left<right){
                int sum = nums[left] + nums[right];
                if(sum>-nums[i]) right--;
                else if(sum<-nums[i]) left++;
                else lists.Add([i,left,right]);
            }
        }

        return lists;
    }
    
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
    }
}