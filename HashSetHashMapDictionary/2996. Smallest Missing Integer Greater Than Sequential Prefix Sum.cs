//Leetcode 2996. Smallest Missing Integer Greater Than Sequential Prefix Sum ez
//题意：给定一个整数数组nums。
//如果对于所有的1 <= j <= i，都满足nums[j] = nums[j - 1] + 1，那么称数组的前缀nums[0..i] 是顺序的。特别地，只有nums[0] 的前缀是顺序的。
//要求返回一个最小的整数x，使得x大于或等于数组的最长顺序前缀的和，并且x不在数组中出现。
//思路：hashtable, 先找到连续数组的前缀和，
//然后找这个前缀和是否再nums中，如果再就+1，不在就return        
//时间复杂度：O(n)
//空间复杂度：O(n)
        public int MissingInteger(int[] nums)
        {
            int res = nums[0];
            for (int i = 1; i < nums.Length; i++)
            {
                if (nums[i] != nums[i - 1] + 1)
                {
                    break;
                }
                res += nums[i];
            }

            HashSet<int> lookup = new HashSet<int>(nums);
            while (lookup.Contains(res))
            {
                res += 1;
            }

            return res;
        }