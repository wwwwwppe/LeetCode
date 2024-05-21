using System.Collections;

namespace Demo15;

class Program
{
    public IList<IList<int>> ThreeSumNew(int[] nums)
    {
        IList<IList<int>> lists = [];
        Array.Sort(nums);
        int n = nums.Length;
        for (var i = 0; i < nums.Length -2; i++)
        {
            if(i>0&&nums[i] == nums[i-1] || nums[i] + nums[^1] + nums[^2] <0) continue;

            var lenRight = n - 1;
            for (int j = lenRight; j >= 0; j--)
            {
                if(j!= n-1 &&nums[j] == nums[j+1]) continue;
                int mid = j - 1;
                while (mid>i)
                {
                    if (nums[i] + nums[mid] + nums[lenRight] == 0)
                    {
                        lists.Add([nums[i],nums[mid],nums[lenRight]]);
                        break;
                    }
                    mid--;
                }
            }
        }

        return lists;
    }
    
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
        int[] nums =
            [-1, 0, 1, 2, -1, -4];
        Program program = new Program();
        program.ThreeSumNew(nums);
        Console.WriteLine("Hello, World!");
    }
}