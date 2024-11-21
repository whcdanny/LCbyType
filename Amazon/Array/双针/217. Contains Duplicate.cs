//Leetcode 217. Contains Duplicate ez
//题目：给定一个整数数组nums，true如果任意值在数组中出现至少两次false则返回，
//如果每个元素都不同则返回。
//思路: 双针，先sort，然后nums[left] == nums[right] true，否则left++; right++;
//时间复杂度：O(nlongn)
//空间复杂度：O(1)
        public bool ContainsDuplicate(int[] nums)
        {
            int left = 0, right = 1;
            if (nums.Length == 1)
                return false;
            Array.Sort(nums);
            while (right < nums.Length)
            {
                if (nums[left] == nums[right])
                    return true;
                else
                {
                    left++;
                    right++;
                }
            }
            return false;
        }