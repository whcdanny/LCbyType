152. Maximum Product Subarray
//C#
public class Solution {
    public int MaxProduct(int[] nums) {
        int res = nums[0];            
        int[] max = new int[nums.Length];
        int[] min = new int[nums.Length];
        max[0] = min[0] = nums[0];                        
        for(int i=1; i < nums.Length; i++)
        {
            if (nums[i] > 0)
            {
                max[i] = Math.Max(nums[i], max[i - 1] * nums[i]);
                min[i] = Math.Min(nums[i], min[i - 1] * nums[i]);
            }
            else
            {
                max[i] = Math.Max(nums[i], min[i - 1] * nums[i]);
                min[i] = Math.Min(nums[i], max[i - 1] * nums[i]);
            }
            res = Math.Max(max[i], res);
        }
        return res;
    }
}

//Java
class Solution {
    public int maxProduct(int[] nums) {
        int[] max = new int[nums.length];
        int[] min = new int[nums.length];
        max[0] = min[0] = nums[0];
        int ans = nums[0];
        for (int i = 1; i < nums.length; i++) {
            if (nums[i] > 0) {
                max[i] = Math.max(nums[i], max[i-1] * nums[i]);
                min[i] = Math.min(nums[i], min[i-1] * nums[i]);
            }else{
                max[i] = Math.max(nums[i], min[i-1] * nums[i]);
                min[i] = Math.min(nums[i], max[i-1] * nums[i]);
            }
            ans = Math.max(max[i], ans);
        }
        return ans;
    }
}